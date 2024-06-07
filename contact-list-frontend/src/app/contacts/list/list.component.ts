import { Component, OnInit, ViewChild } from '@angular/core';
import { forkJoin } from 'rxjs';

import { ApiService } from '../../shared/services/api.service';
import { GeneralService } from '../../shared/services/general.service';

import { LoadingComponent } from '../../shared/components/loading/loading.component';
import { TableComponent } from './components/table/table.component';
import { FormModalComponent } from './components/form-modal/form-modal.component';
import { DeleteModalComponent } from './components/delete-modal/delete-modal.component';

import { IContact } from '../../shared/interfaces/contact';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [TableComponent, FormModalComponent, LoadingComponent, DeleteModalComponent],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss'
})
export class ListComponent implements OnInit {
  @ViewChild(FormModalComponent) formModal!: FormModalComponent;
  @ViewChild(DeleteModalComponent) deleteModal!: DeleteModalComponent;

  contactModalOpen: boolean = false;
  confirmDeleteModalOpen: boolean = false;
  selectedContact: IContact | undefined;
  editMode: boolean = false;
  resolvingData: boolean = false;
  error: string | null = null;

  contacts: IContact[] = [];

  constructor(private apiService: ApiService, private generalService: GeneralService) { }

  ngOnInit(): void {
    // load contacts, states, and contact frequencies from DB
    this.resolvingData = true;
    forkJoin({
      contacts: this.apiService.getContacts(),
      states: this.generalService.loadStates(),
      contactFrequencies: this.generalService.loadContactFrequencies()
    }).subscribe({
      next: ({ contacts }) => {
        this.contacts = contacts;
        this.resolvingData = false;
      },
      error: (error) => {
        this.error = this.processError(error);
        this.resolvingData = false;
      }
    });
  }

  // opens modal for viewing or editing contact when contact is passed in.
  // otherwise, opens modal for adding a new contact.
  openContactModal(contact: IContact | undefined = undefined, editMode: boolean = false) {
    this.selectedContact = contact;
    this.editMode = editMode;
    this.contactModalOpen = true;
  }

  closeContactModal() {
    this.selectedContact = undefined;
    this.editMode = false;
    this.contactModalOpen = false;
  }

  // pass contact data to parent component to handle save
  // if contact has an id, it's an existing contact and we'll update it.
  // otherwise, it's a new contact and we'll add it.
  onSubmit(contact: IContact) {
    if (contact?.id && contact.id > 0) {
      this.apiService.updateContact(contact).subscribe({
        next: (updatedContact: any) => {
          const index = this.contacts.findIndex(c => c.id === updatedContact.id);
          if (index != -1) this.contacts[index] = contact;
          this.closeContactModal();
        },
        error: (error) => {
          this.onSaveError(this.processError(error));
        }
      });
    } else {
      this.apiService.addContact(contact).subscribe({
        next: (newContact) => {
          this.contacts.push(newContact);
          this.closeContactModal();
        },
        error: (error) => {
          this.onSaveError(this.processError(error));
        }
      });
    }
  }

  // open delete modal for selected contact rather than deleting immediately
  openDeleteModal(contact: IContact) {
    this.selectedContact = contact;
    this.confirmDeleteModalOpen = true;
  }

  confirmDelete() {
    if (this.selectedContact?.id && this.selectedContact.id > 0) {
      this.apiService.deleteContact(this.selectedContact.id).subscribe({
        next: () => {
          this.contacts = this.contacts.filter(c => c.id !== this.selectedContact?.id);
          this.closeConfirmDeleteModal();
        },
        error: (error) => {
          this.onDeleteError(this.processError(error));
        }
      });
    }
  }

  closeConfirmDeleteModal() {
    this.selectedContact = undefined;
    this.confirmDeleteModalOpen = false;
  }

  // pretty simple error handling
  processError(error: any) {
    if (error.status === 0) {
      return 'An error occurred while connecting to the server.';
    }
    return error.error ? error.error : 'An error occurred while deleting the contact.';
  }

  // pass error to form modal to display
  onSaveError(error: string) {
    if (this.formModal) {
      this.formModal.onError(error);
    }
  }

  // pass error to delete modal to display
  onDeleteError(error: string) {
    if (this.deleteModal) {
      this.deleteModal.onError(error);
    }
  }
}
