# Basics

## launchSettings.json

Like .NET Core WebAPI this file contains profiles to run the application. Nothing else.

## wwwroot

This folder contains all the static files like `.css`, `.js` and images. So, if we requires any static files in the application we will add that to this folder.

## appsettings.json

This file contains config like database connection strings.

## .NET Core Request/Middleware Pipeline

Pipeline consists of different middlewares like `Auth`, `MVC`, `Static Files` etc. When our app server receives a request from the browser, it sends that request through this pipeline where each middlewares modify the request and response as per their functionality before passing it to the next middleware.

**Order of middleware pipeline is extremely important. As there may be a middleware which requires some information attached to the request/response and attaching that information to the request/response was the responsibility of another middleware.**

```

app.UseAuthorization()
app.UseAuthentication()

```

For example, above code won't work. Because we always authorize the users those are authenticated. So, we should use the `Authentication` middleware before using the `Authorization` middleware.

We can identify the middlewares in the `Program.cs` class by the prefix `app.Use`.

## Model

A model represents the shape of data. It is basically a `.cs` file which consists of property. A model can represent a database table or can represent the combination of multiple table.

A model can be used to transfer data between views and controllers.

## View

View represents the user interface. Whatever we see in our web app is basically view. 
## Controller

Controller acts as an interface between model and views to process all the business logic and incoming requests. It manipulates the data using model and interacts with view to render the final output.

When a user clicks a button Controller receives that request. Controllers have lots of action methods. Controller will redirect that request to one of the action method. Controller will fetch the data from model and will place inside the view. Once the view is rendered, it will pass it to the controller. And controller will sends back the response.

## Routing

The URL pattern for routing

`http://localhost:5001/{controller}/{action}/{id}`

```

---------------------------------------------------------------------------------------------
URL												Controller			Action			Id		|
---------------------------------------------------------------------------------------------
http://localhost:5001/Category/Index			Category			Index			NULL	|
																							|
http://localhost:5001/Category					Category			Index			NULL	|
																							|
http://localhost:5001/Category/Edit/3			Category			Edit			3		|
																							|
http://localhost:5001/Product/Details/3			Product				Details			3		|
---------------------------------------------------------------------------------------------

```

We have View associated with each action. When we navigate to a route it, it renders the view associated with that action. If we don't specify any action at the route, it renders the `Index` view.


- `_Layout.cshtml` inside `Shared` folder is the master template on top of which the whole application renders. Just like the `index.html` file of a react application.
- `_ValidationScriptsPartial.cshtml` is a partial view which we can use whenever we need Validation Views.
- In `_ViewImports.cshtml` file contains the global namespace. If we add any namespace in this file, it will be accessible throughout the application. By this way, we don't have to import that namespace in each places we want to use it. In this file, `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers` add all the tag helpers provided by `ASPNETCORE.MVC`.
- In `_ViewStart.cshtml` file we declare the master file (like `index.html`) our application will use.

## Tag Helpers

- Tag Helpers are introduced with ASP.NET Core.
- Tag Helpers is like Angular Directives. But Tag Helpers is for server side rendering and the Angular directive is for client side.
- Tag Helpers start with the prefix `asp-`.

## Action Result

```

public IActionResult Index()
{
	return View();
}

```

or

```

public ViewResult Index()
{
	return View();
}

```

Both the above code is valid for MVC application.

- IActionResult is a result of action methods/pages or return types of action methods/page handlers.
- IActionResult is a parent class for many of the derived classes that have asscoiated helpers.
- The IActionResult return type is appropriate when multiple ActionResult return types are possible in an action. That means when we return multiple ActionResult based on some conditions, then we have to use IActionResult.


### Different Action Result in Razor Pages

- **ContentResult**
	- **Content:** Takes a string and returns it with a text/plain content-type header by default. Overloads enable you to specify the content-type to return other formats such as text/html or application/json.
- **FileContentResult**
	- **File:** Returns a file from a byte array, stream or virtual path.
- **NotFoundResult**
	- **NotFound:** Returns status code 404.
- **PageResult**
	- **Page:** Will process and return the result of the current page.
- **PartialResult**
	- **Partial:** Returns a partial page.
- **RedirectsToPageResult:** `RedirectToPage`, `RedirectToPagePermanent`, `RedirectToPagePreserveMethod`, `RedirectToPagePreserveMethodPermanent` all the helpers redirect the user to the specified page.
- **ViewComponentResult:** Returns the result of executing a ViewComponent.

### Different Action Result in MVC

- **ViewResult - View -** Renders a view as a Web page.
- **PartialViewResult - PartialView-** Renders a partial view, which defines a section of a view that can be rendered inside another view.
- **RedirectResult - Redirect-** Redirects to another action method by using its URL.
- **ContentResult - Content-** Returns a user-defined content type.
- **JsonResult - Json-** Returns a serialized JSON object.
- **JavaScriptResult - JavaScript-** Returns a script that can be executed on the client.
- **FileResult - File-** Returns binary output to write to the response.
- **EmptyResult - (None)-** Represents a return value that is used if the action must return a null value.

<hr>

# Code First vs Database First Migration

Code First approach is we write code, then based on that code ORM creates necessary migration files to sync the database.

Database First approach is we setup everything in database, then we write code to use those Database tables based on those constraint we setup.

<hr>

## EFCore Migrations

Migration is basically keeping the track of all the DB changes that are needed. Once we created the migration, we push that migration to the database to make those changes to our tables.

- We can add migration using the command `add-migration {nameOfMigration}`.
- We need the NUGET package EFCore.Tools to create migration.
- When we create migration, there will be created a file with the name of migration which contains two methods `up` and `down`. `up` method do all such things that needs to be done in this migration and `down` method do all such things that needs to be done to revert this migration.
- We can push migration to the database using the command `update-database`.

<hr>

# 


https://www.youtube.com/watch?v=hZ1DASYd9rk