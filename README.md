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

Images
![image](https://user-images.githubusercontent.com/62305841/122102986-0ed4d980-cde4-11eb-83cc-f169d5ef3f59.png)
Index/Now Playing page, Jumbotron, Sticky Navbar

![image](https://user-images.githubusercontent.com/62305841/122103048-24e29a00-cde4-11eb-89eb-4d26f6f77d4a.png)
Index/Now Playing page, Carousel

![image](https://user-images.githubusercontent.com/62305841/122103098-388e0080-cde4-11eb-9eb6-7fdc3d6bd0d9.png)
Index/Now Playing page, Now Playing results table

![image](https://user-images.githubusercontent.com/62305841/122103134-43489580-cde4-11eb-90d5-89663eb21845.png)
Search By Title results page, featuring top 3 matches, and results table

![image](https://user-images.githubusercontent.com/62305841/122103182-53f90b80-cde4-11eb-9a82-88531cce04d1.png)
Movie Details page, with all info present, dropdown menu for links to trailers on youtube, like/dislike buttons

![image](https://user-images.githubusercontent.com/62305841/122103264-6c692600-cde4-11eb-8442-0f7debd6d261.png)
Movie Details pages load dynamically, unreleased or canceled titles won't display missing info 
