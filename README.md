# ContactList

This is a project using both Angular 18 and .NET 8 Web API to run a contact list CRUD application.
You should see 10 records populated for Contacts to start. 
Use the Add Contact button at the top right of the table to enter a new contact.
Click one of the action buttons on the right of each row to view, edit, or delete a contact.

### Project notes are at the bottom as to not muddy up the setup instructions

## Project setup

### Clone ContactList repo

This repository contains the projects for both the frontend (Angular) and backend (.NET 8 Web API).  
I run Angular in VS Code and .NET in Visual Studio.

### Open contact-list-backend folder in Visual Studio 2022

Open contact-list-backend.sln (sorry about the naming...)  
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

# Good to go!
Hopefully. Otherwise, email me at cdtown3@gmail.com and I can help!

# ContactList Notes

## Frontend

The frontend is written in TypeScript using Angular v18 as my framework. This is my most comfortable frontend framework as of now.  

I'm using TailwindCSS for styling and ngx-mask for enforcing requirements on user input (namely zipcode, phone number). Everything else is out-of-the-box Angular.  
What I tried to do was simplify the implementation by breaking different functionality into their own components, pretty standard. The list component is setup as the app's entry point and on
initialization it resolves the contact data, state options, and contact frequencies. The latter 2 are loaded into the general service (which holds basic app info, like states and the contact frequencies).  

I used interfaces on all the API models to enforce type safety.  

I tried to ensure the app was responsive on mobile using tailwind classes. My mobile test was using an iPhone SE in browser, which has a pretty narrow width, and I was able to get the table looking good, but you'll notice some
data does disappear on smaller screens. It was between this or small, hard to read data. But the user still has the option to click the view icon for each contact to see more info.  

For error handling, I believe the frontend is tight enough to not send any unrecognizable or weird data to the backend. Of course, I also have validation on the backend in case of a bad actor just hitting the API direct.  

Last note, I hope the use of modals was okay. I felt this was a good place to implement that style.

## Backend

The backend is written in .NET 8 and is using Entity framework core.  

As requested, I'm using the in-memory database and seeding it 10 contact records, all states + DC, and the 3 possible contact frequency options.  

Each Entity model contains attributes for validation, along with 2 custom ones using RegularExpression to ensure numerical strings on zipcode and phone number.  

Services are created inheriting from interfaces, which allows us to easily decouple the controllers and provide them with mock services for testing later. The services contain the logic for some custom validation
and saving the changes.  

Side note, might be a weird choice to leave contact frequency endpoint in with the ContactController, but I figured it was so tightly related, it made sense.
