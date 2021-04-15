# PeopleAndPets sample project
[Use the Angular project template with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-5.0&tabs=visual-studio)

## Prerequisite
You will need .net core 3.1 SDK

## Restore npm packages
On "PeopleAndPets.WebUI\ClientApp" folder
```bash
npm i
```

## Rebuild solution
In visual studio -> Rebuild solution (should restore NuGet packages automatically)

## Running the project
Set "PeopleAndPets.WebUI" as a Startup project, press F5

![alt text](https://github.com/AsankaMawilmada/PeopleAndPets/blob/main/Screenshots/Running%20application.PNG?raw=true)

## Unit tests

### Backend
In visual studio, open Test Explore -> Run all tests

![alt text](https://github.com/AsankaMawilmada/PeopleAndPets/blob/main/Screenshots/VisualStudio%202019%20Test%20Explorer.PNG?raw=true)

### Frontend
Open the command line and go to \PeopleAndPets.WebUI\ClientApp folder, run
```bash
ng test
```
![alt text](https://github.com/AsankaMawilmada/PeopleAndPets/blob/main/Screenshots/Jesmine%20unit%20tests%20results.PNG?raw=true)

## License
[MIT](https://choosealicense.com/licenses/mit/)