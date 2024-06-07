import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { IContact } from '../interfaces/contact';
import { IState } from '../interfaces/state';
import { IContactFrequency } from '../interfaces/contact-frequency';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl = 'https://localhost:7287';

  constructor(private httpClient: HttpClient) { }

  getContacts(): Observable<IContact[]> {
    return this.httpClient.get(`${this.baseUrl}/Contacts`).pipe(
      map((response: any) => response as IContact[])
    );
  }

  addContact(contact: any): Observable<IContact> {
    return this.httpClient.post(`${this.baseUrl}/Contacts`, contact).pipe(
      map((response: any) => response as IContact)
    );
  }

  updateContact(contact: any): Observable<IContact> {
    return this.httpClient.put(`${this.baseUrl}/Contacts`, contact).pipe(
      map((response: any) => response as IContact)
    );
  }

  deleteContact(id: number): Observable<number> {
    return this.httpClient.delete(`${this.baseUrl}/Contacts?id=${id}`).pipe(
      map((response: any) => response as number)
    );
  }

  getStates(): Observable<IState> {
    return this.httpClient.get(`${this.baseUrl}/State`).pipe(
      map((response: any) => response as IState)
    );
  }

  getContactFrequencies(): Observable<IContactFrequency> {
    return this.httpClient.get(`${this.baseUrl}/ContactFrequency`).pipe(
      map((response: any) => response as IContactFrequency)
    );
  }
}
