# ContactsManagementApp

Framework Used for Api
===================
  .Net8

Installation
==============
1.Clone the repo:
      git clone https://github.com/siju0013/ContactsManagementApp.git
2. Open the .csproj file expore location in command prompt(Administrative mode)
3. Run the command
    dotnet run
4. Open the browser paste the link below to check whether the api is running
    http://localhost:5211/swagger
This api project is designed like layered architecture. Reading json file and listing contacts is done globaly using sigleton class. All logics are written in bussines logic folder containing a class. This communicate with dataservice for all crud operation activities and list full contacts. Validation, mandatory fields are defined within the model class. Exceptions ar handled globally using IExceptionHandler. For Implementing exception globaly, midlewear is being used. All Contacts written in contact.json file.

Note: Since read and write operations is hapenning in json file. When multiple request happens at same time there is a chance of impacting the integrity of data. For such operation is better to use other sources like sqlite, sql etc

Framework Used for Web Applciation
==================================
Angular 17 & Boostrap 5

Indtallation of WebApplication
============================
1.Clone the repo:
      git clone https://github.com/siju0013/ContactsManagementApp.git
2. Install NPM Packages
    npm install
3. For running application and for running in new browser
    ng s -o
Api endpoint are stored in Environment ts file. Boostrap5 is used for layout and design. Boostrap css and js path is added in angular.json file. Here Appcomponent is working as parent component and child components are modify and List. Communication between parent & child component is used with the help of @Input() and @Output decorator. Rxjs is used make observable api request. Alert is used for error handling.
