import { Injectable } from '@angular/core';
import { map } from 'rxjs';

import { ApiService } from './api.service';

import { IState } from '../interfaces/state';
import { IContactFrequency } from '../interfaces/contact-frequency';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  states: IState[] = [];
  contactFrequencies: IContactFrequency[] = [];

  constructor(private api: ApiService) { }

  loadStates() {
    return this.api.getStates().pipe(map((states: any) => {
      this.states = states;
    }));
  }

  loadContactFrequencies() {
    return this.api.getContactFrequencies().pipe(map((frequencies: any) => {
      this.contactFrequencies = frequencies;
    }));
  }

}
