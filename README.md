# factory-order-database-gui

[![standard-readme compliant](https://img.shields.io/badge/standard--readme-OK-green.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)

A WPF desktop app for storing and displaying transportation and sales data for a
cotton factory using data binding.

[@ameshkahloon](https://github.com/ameshkahloon) proposed that he and I try
building the app to help his family member who works as a Cotton Oil Factory
manager inventory and sales data. This is the result of the endeavour!

See <https://github.com/ameshkahloon/Cotton-OIL-Factory-Database> for the final
version of the app after I finished working on it. I'm keeping this repo to
maintain our commit history.

## Table of Contents

<!--toc:start-->

- [Install](#install)
- [Usage](#usage)
- [Maintainers](#maintainers)
- [Contributing](#contributing)
- [License](#license)

<!--toc:end-->

## Install

Prerequisites:

- [Visual Studio](https://visualstudio.microsoft.com/)
- [SQL Server](https://learn.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server-from-the-installation-wizard-setup?view=sql-server-ver16)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

Steps:

1. Clone the project.
1. Open the project in [Visual Studio](https://visualstudio.microsoft.com/)
1. Use the two `.sql` files under the `db/` folder to make two tables in your
   data base server. i.e., SSMS connected to a SQL Server.
1. Add the data connection of the database containing the two tables and
   then add the two tables as a data source in the solution. Note the connection
   string.
1. Go to the `Database/` folder of the projects solution and open the
   `LinqToSqlConnection.cs` file insert the correct connection string after the
   `.Settings.` in the `connectionString` variable.
1. Insert all the nuget packages present in the package.config file to the
   project solution.
1. Start the project.

## Usage

<details><summary>Screenshots</summary>

![Home Window](https://github.com/user-attachments/assets/34f4fa1b-7377-45af-a0ba-2ce7f330ed86)
![Transportation Confirmation Data](https://user-images.githubusercontent.com/44043757/81600924-62325800-9398-11ea-87f0-b3ad532cdc4b.png)
![Transportation MessageBox Confirmation](https://user-images.githubusercontent.com/44043757/81601352-b89f9680-9398-11ea-9bb8-298994a822a7.png)
![Transportation Data Search](https://user-images.githubusercontent.com/44043757/81601375-c228fe80-9398-11ea-9909-9d5e2c379a7c.png)
![Sales Confirmation Data](https://user-images.githubusercontent.com/44043757/81601378-c3f2c200-9398-11ea-98d4-cbbef4a701f9.png)
![Sales Input Data](https://user-images.githubusercontent.com/44043757/81601384-c6551c00-9398-11ea-9a91-838eb4d21339.png)
![Transportation Input Data](https://user-images.githubusercontent.com/44043757/81601391-c9500c80-9398-11ea-9d6a-637d72007263.png)
![Home Screen](https://user-images.githubusercontent.com/44043757/81601404-d0771a80-9398-11ea-9d18-042ec97e4f5c.png)
![Sales Data Search](https://user-images.githubusercontent.com/44043757/81601408-d10fb100-9398-11ea-84ed-12e5d4b95e22.png)

</details>

## Maintainers

[@bryan-hoang](https://github.com/bryan-hoang),
[@ameshkahloon](https://github.com/ameshkahloon)

## Contributing

Small note: If editing the README, please conform to the
[standard-readme](https://github.com/RichardLitt/standard-readme) specification.

## License

MIT © 2024 Bryan Hoang, Amesh Kahloon
