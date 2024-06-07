import { Component, EventEmitter, Input, Output } from '@angular/core';

import { IContact } from '../../../../shared/interfaces/contact';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss'
})
export class TableComponent {
  @Input() contactData: IContact[] = [];
  @Output() viewContact: EventEmitter<IContact> = new EventEmitter<IContact>();
  @Output() editContact: EventEmitter<IContact> = new EventEmitter<IContact>();
  @Output() deleteContact: EventEmitter<IContact> = new EventEmitter<IContact>();

  // open contact details modal
  onView(contact: IContact): void {
    this.viewContact.emit(contact);
  }

  // open contact edit modal
  onEdit(contact: IContact): void {
    this.editContact.emit(contact);
  }

  // open contact delete modal
  onDelete(contact: IContact): void {
    this.deleteContact.emit(contact);
  }

  // mask phone number to (000) 000-0000
  maskPhoneNumber(phoneNumber: string): string {
    return phoneNumber?.replace(/(\d{3})(\d{3})(\d{4})/, '($1) $2-$3');
  }

  // Some text can be too long for the table, so we'll truncate it
  maskText(text: string, maxLength: number = 20): string {
    return text?.length > maxLength ? text?.substring(0, maxLength) + '...' : text;
  }
}
