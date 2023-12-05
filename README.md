# First Web-Api Project
The project we built is a store website for household and kitchenware.
## Description
The project includes a secure login and registration system. We test password strength using the ZXCVBN library. After logging in, you can update the user information and go to the products page where you can filter the products and add products to the cart. On the basket page you can remove products and place an order.
## How to use
The project should be run using VS 2022 and above.
SQL DB. You can use the ability of code first by running these commands in the Package Managment Console:
```bash
add-migration Store325574630
```
```bash
Update-Database
```
## Structure
The project is a Web-Api project written in .NET 7.0. 
We kept the REST architecture and used the MVC layer model. The layers communicates in DI to add encapsulation and scalability. 
In addition, we used async/await throughout the project to get scalability. 
We wrote the project using the DB first method, and used the entity- framework ORM to work with the data using C# objects. 
We used DTO to flatten objects and remove circular dependencies. We mapped the objects using the AutoMapper library. 
We made sure to use config files to store information that can be changed between different environments. 
We made sure to write to the log, an active log that in case of an error sends an email to the administrator. 
We added middleware to catch errors that occurred throughout the project and midllware to document the rating. 
The entire project has a documented swagger.
