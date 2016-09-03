Web Application Security Examples
---

Example projects for demonstrating Web application securities

## Table Of Contents
 * [Prerequisites](#prerequisites)
 * [Preparation](#preparation)
 * [Guides for doing hands-on exercises](#guides-for-doing-hands-on-exercises)
 * [Hands-on exercises](#hands-on-exercises)
   * [Basic authentication](#basic-authentication)

## Prerequisites
* Basic knowledge of C#
* Basic knowledge of JavaScript and HTML
* Basic knowledge of HTTP and Web

## Preparation
To be able to run hands-on excercises, install below listed tools:
* Install [Git](https://git-scm.com/)
* Install [Visual Studio Code](https://code.visualstudio.com/)
* Install [C# extension for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
* Install [.NET Core](https://www.microsoft.com/net/core)
* Install [Chrome](https://www.google.com/chrome/)
* Install [JSONView extension for Chrome](https://chrome.google.com/webstore/detail/jsonview/chklaanhfefbnpoihckbnefhakgolnmc)
* Install [Postman application for Chrome](https://chrome.google.com/webstore/detail/postman/fhbjgbiflinjbdggehcddcbncdddomop)

## Guides for doing hands-on exercises
[to be documented]

## Hands-on exercises
### Basic authentication (C# .NET Core)
Firstly, view and run the Books.Api web application project
 1. From terminal (cmd on Windows), navigate to authentication/basic folder
 2. Type `code .` from terminal to open the project
 3. Type `dotnet run` from terminal to run the web application
 4. From Chrome browser, enter http://localhost:5000/books
 5. A list of books (in JSON format) will be displayed in browser

There is no authentication check in the API (http://localhost:5000/books), Now add basic authentication for it:
 1. Locate file `BooksController.cs`
 2. Add `[Authorize(ActiveAuthenticationSchemes = "Basic")]` attribute to the `Get()` method to add Basic authentication for the API
 3. Re-run the application and visit http://localhost:5000/books
 4. There should be a popup windows asking for credentials
 5. Try to input some random invalid credentials, browser should keep asking credentials
 6. Input the hard-coded credentials `admin:admin`, then the books list should be returned.
 7. For the authentication details, go to `BasicAuthenticationHandler.cs` to view the details.
