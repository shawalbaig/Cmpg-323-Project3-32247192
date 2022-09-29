# Cmpg-323-Project3-32247192
Cmpg 323 project 3 is based on an existing ASP.NET Core MVC Web Application that requires some modification.

## Repository Pattern 
<br />The goal of the repository  is to establish an abstraction layer between an application's business logic layer and data access layer.
By putting these patterns into practice, you can protect your application against changes in the data store and make test-driven development or automated unit testing easier.
<br />
<br />
<br />For this Web Application Tier 2 repository pattern is implimented.
<br />
<br />The diagram below shows how tier 2 repository pattern looks like:


![image](https://user-images.githubusercontent.com/88322853/192659008-20d1231c-1e7a-4158-a108-dcd64321cb9d.png)


Link to the page : https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
<br />
<br />
### Implimentation of Tier 2 Repository pattern
<br /> A new repository class and an interface class is created for each of the controllers
<br /> All the code from the controllers is transfered to the repository class
<br /> all the methods are called from the interface class instead of the controller class therefore implimenting polymorphism 

## Project 3 API description 
<br /> //GET: /Categories
<br /> // GET: /Categories/Details/5 
<br /> // POST: Categories/Create 
<br /> // GET: Categories/Edit/5 
<br /> // POST: Categories/Edit/5
<br /> //GET: Categories/Delete/5




