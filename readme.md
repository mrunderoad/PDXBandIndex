# _PDX Band Index_

### _By: Isaac Overstreet_

#### _short description_

## Technologies Used

* _C#_
* _MySQL_
* _cshtml_
* _CSS_
* _Bootstrap_
* _Entity Framework_
* _.NET_
* _Identity_

## Description

_description._

## Setup/Installation Requirements

* _Make sure you have MySQL Workbench installed._
* _Clone this repository to your desktop from `___  ___`_
* _Navigate to the HairSalon directory in your terminal using `cd PDXBandIndex`._
* _Inside the `PDXBandIndex` directory, add a new file named `appsettings.json`._
* _Inside the `appsettings.json` file, add this code with your database, username and password in the specified places in the code._ 
```c#
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=DATABASE HERE;uid=USERNAME;pwd=PASSWORD;"
  }
}
```
* _Inside the `PDXBandIndex` directory, run `dotnet ef database update` to create a database based off the migrations folder included in the repository._
* _Run `dotnet restore` to restore the obj and bin folders._
* _Run `dotnet build` to build the project._
* _Run `dotnet run` to start a localhost. `ctrl+click` on the localhost option in your terminal to view the project in your browser._

## Known Bugs

* _Plenty of bugs right now_

## License

[MIT](https://opensource.org/licenses/MIT)

_Copyright (c) 2022  Isaac Overstreet_