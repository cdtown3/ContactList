# ContactList

This is a project using both Angular 18 and .NET 8 Web API to run a contact list CRUD application.
You should see 10 records populated for Contacts to start. 
Use the Add Contact button at the top right of the table to enter a new contact.
Click one of the action buttons on the right of each row to view, edit, or delete a contact.

### Project notes are at the bottom as to not muddy up the setup instructions

# Project setup

### Clone ContactList repo

This repository contains the projects for both the frontend (Angular) and backend (.NET 8 Web API).  
I run Angular in VS Code and .NET in Visual Studio.

### Open contact-list-backend folder in Visual Studio 2022

Open contact-list-backend.sln 
Next, build the project.  
On success, run the project in debug.  
You should be greeted with swagger's index page showing the possible endpoints.  
Feel free to play around here and test.

### Install Node.js and Angular CLI

You'll need [Node.js](https://nodejs.org/) which should also include NPM.  
I'm using npm v10.8.1 and Node.js v18.19.1  
Next, open your terminal and install Angular CLI: `npm install -g @angular/cli`

### Open contact-list-frontend folder in VS code

Once inside this folder, open the terminal in the same folder and run: `npm i`  
This should install all required modules used in the application  

To start the project, run `npm run start`

### Using the application

The hardest part should hopefully be done now!  

With both projects running, open up a new tab and navigate to http://localhost:4200  
Upon load you should see the contact table, along with action buttons on the right side.

## Good to go!
Hopefully.
