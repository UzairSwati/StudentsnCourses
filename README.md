# Project Description

It is basically a CRUD project involving _Students_ and _Courses_.

**Architecture :** Micro Services

## Built With

**.NET Core** | **SQL Server** | **Angular**


## About the Services

**Students :** This serivce is responsible for all CRUD operation involving _Student_ Entity.

**Courses :** This serivce is responsible for all CRUD operation involving _Course_ Entity.

**ApiGateway :** This serivce is responsible for all the interactions between the underlying services and Client side. This is basically a centeralized point to handle all the traffic and can be configured to have the restrictions or constraints related to underlying services, if any. The _Upstream_ and _Downstream_ bindings can be found in _ocelot.json_ and changed accordingly.

## Client Side

**get-students-list-app :** This Angular app is responsible for displaying the _Students_ list. It is currently displaying the data from an online sample Api but the desired Api url can be placed in **app.component.ts** and properties mapping might need to be changed in **app.component.html**.


## How to Run [After Clonning the repo]

**.NET Services :** All three services need to be in running state by using _multiple startup projects_ or starting each service individually. Most importantly, all services should be using unique and available ports which can be configured in _launchSettings.json_. All the communication should go pass the _ApiGateway_ and _ocelot.json_ file should be used as a reference. For example, _https://localhost:port/students/{id}_ and _https://localhost:port/courses/{id}_ can be used to get a specific _Student_ and _Course_ record respectively.

**Angular App :** This app can be started by _using ng s --open_ command in _VS Code_. Api Url and data properties might need to be mapped accordingly as explained earlier.
