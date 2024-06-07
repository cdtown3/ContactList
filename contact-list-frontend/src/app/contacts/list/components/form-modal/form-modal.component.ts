import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgxMaskDirective } from 'ngx-mask';

import { GeneralService } from '../../../../shared/services/general.service';

import { LoadingComponent } from '../../../../shared/components/loading/loading.component';

import { IContact } from '../../../../shared/interfaces/contact';

@Component({
  selector: 'app-form-modal',
  standalone: true,
  imports: [ReactiveFormsModule, NgxMaskDirective, LoadingComponent],
  templateUrl: './form-modal.component.html',
  styleUrl: './form-modal.component.scss'
})
export class FormModalComponent implements OnInit {
  @Input() contact: IContact | undefined;
  @Input() editMode: boolean = false;
  @Output() saveContact: EventEmitter<IContact> = new EventEmitter<IContact>();
  @Output() closeModal: EventEmitter<void> = new EventEmitter<void>();
  
  errorMessage: string | null = null;
  isSaving: boolean = false;
  contactForm: FormGroup;

  constructor(private fb: FormBuilder, public generalService: GeneralService) {
    this.contactForm = this.fb.group({
      id: [0],
      firstName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(20)]],
      lastName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(20)]],
      emailAddress: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      address: this.fb.group({
        street: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(100)]],
        city: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]],
        state: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(2)]],
        zip: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(5)]]
      }),
      contactFrequencyId: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // if contact is passed in, populate form with contact data
    if (this.contact) {
      this.contactForm.patchValue(this.contact);
    }
    if (!this.editMode) {
      this.contactForm.disable();
    }
  }

  editForm(): void {
    this.editMode = true;
    this.contactForm.enable();
  }

  // pass form data to parent component to handle save
  onSave(): void {
    if (this.contactForm.valid) {
      this.isSaving = true;
      this.errorMessage = null;
      this.saveContact.emit(this.contactForm.value);
    }
  }

  onClose(): void {
    this.closeModal.emit();
  }

  onError(error: string): void {
    this.isSaving = false;
    this.errorMessage = error;
  }
}
