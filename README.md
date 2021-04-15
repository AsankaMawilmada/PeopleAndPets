# PeopleAndPets sample project
[Use the Angular project template with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-5.0&tabs=visual-studio)

## Prerequisite
You will need .net core 3.1 SDK 

## Restore npm packges 
On "PeopleAndPets.WebUI\ClientApp" folder
```bash
npm i
```

## Rebuild solution
In visual studio -> Rebuild solution (should restore NuGet packages automattically)

## Runing the project
Set "PeopleAndPets.WebUI" as Startup project

## Unit tests

### Backedend
In visual studio, open Test Explore -> Run all tests
		
### Frontend
Open command line and go to \PeopleAndPets.WebUI\ClientApp folder, run 
```bash
ng test
```

## License
[MIT](https://choosealicense.com/licenses/mit/)