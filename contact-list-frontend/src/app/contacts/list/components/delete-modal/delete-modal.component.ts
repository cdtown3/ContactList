import { Component, EventEmitter, Input, Output } from '@angular/core';

import { LoadingComponent } from '../../../../shared/components/loading/loading.component';

import { IContact } from '../../../../shared/interfaces/contact';


@Component({
  selector: 'app-delete-modal',
  standalone: true,
  imports: [LoadingComponent],
  templateUrl: './delete-modal.component.html',
  styleUrl: './delete-modal.component.scss'
})
export class DeleteModalComponent {
  @Input() contact: IContact | undefined;
  @Output() confirmDelete: EventEmitter<void> = new EventEmitter<void>();
  @Output() cancelDelete: EventEmitter<void> = new EventEmitter<void>();

  errorMessage: string | null = null;
  deletingContact: boolean = false;

  constructor() { }

  // let parent know it's good to delete
  onDeleteContact() {
    this.deletingContact = true;
    this.confirmDelete.emit();
  }

  onCancelDelete() {
    this.cancelDelete.emit();
  }

  onError(error: string) {
    this.deletingContact = false;
    this.errorMessage = error;
  }
}
