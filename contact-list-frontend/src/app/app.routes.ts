import { Routes } from '@angular/router';
import { ListComponent } from './contacts/list/list.component';

export const routes: Routes = [
    {
        path: "list",
        component: ListComponent,
    },
    {
        path: "**",
        redirectTo: "list"
    }
];
