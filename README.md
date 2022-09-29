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
<br />    GET: /Categories : The data is returned if the given GUID has read access to it. 
<br />    GET: /Categories/Details/5 : The details is returned if the given GUID has read access to it.
<br />    POST: Categories/Create: A GUID that can be used to read, edit, delete, or provide access to the data is returned by the API when the data store receives the request body. 
<br />    GET: Categories/Edit/5 : if the given GUID has edit access to any data , that information is returned and displayed and then updated to serve as the request's bosy.
<br />    POST: Categories/Edit/5 : If the given GUID has update access to any data, that information is updated to serve as the request's body.
<br />    GET: Categories/Delete/5: Access needs to be a string that includes the letters r (read), u (update), and d. (delete).
A new GUID is provided that has the required access rights on the specified GUID if the access requested is the same as or a subset of the access on the supplied GUID. 
## Building 





