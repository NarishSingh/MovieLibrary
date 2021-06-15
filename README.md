# MovieLibrary

"Movie Library" - full stack C# web app by Narish Singh

A simple web app in MVC structure where you can browse currently playing movies, search for titles and view their
information, and leave a like or dislike. Uses the MovieDb API (https://www.themoviedb.org/)

Tech stack - C# .Net Framework ASP.NET Web App

- Backend: HttpClient and async code for interacting with the external API, Newtonsoft.Json for (de)serialization
  between objects and JSON, Dapper ORM for data access to the MS SQL database through stored procedures, NUnit for DAO
  and Service layer testing
- Front end: C# Razor pages, jQuery and jQuery Validation, Bootstrap 4.5

Running the app:

1. Install the database and stored procedures: in Microsoft SQL Server, ensure you are using your System Admin login and
   are using Mixed authentication. The install script `DbEasyInstall.sql` combines all SQL scripts and has been placed
   at the root of the repo for your convenience. Running the script with define the database, create the necessary
   stored procedure for CRUD, and create the sample data for backend testing
2. Connect app to your db: you will need to put your Microsoft SQL Server password for your system admin login into 2
   config files in the app for the backend to test and run the code. In both cases, you will add your `Password` in
   the `connectionString` value of the configuration. Note that by default system admin logins are aliased 'sa', if you
   login differs you must update the `User Id` value accordingly <br/>
   `<connectionStrings>
   <add name="MovieLibrary" connectionString="Server=localhost;Database=MovieLibrary;User Id=sa;Password=;"
   providerName="System.Data.SqlClient" />
   </connectionStrings>`
   <br/> These files are, from the repo root:
    - MovieLibrary/MovieLibrary.Test/App.config
    - MovieLibrary/MovieLibrary.UI/Web.config
3. Running the app will require IIS Express. If you plan to run the app from Visual Studio, you likely will have IIS
   Express installed already with your C# bundle. If you are running from another IDE such as Rider, be sure to install
   it from https://www.microsoft.com/en-us/download/details.aspx?id=48264
4. Lastly, build the solution and run the app, and navigate to `http://localhost:5000/` to view the application