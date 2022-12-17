# B9IS123_10612366_10622824_10612648_10605157_InformationSystems

Note (Login Hash): We have added the base64 hash encryption for login authentication can be validated by the User table in the database which was not included in the code during the presentation ------- Discussed with Paul in the class to add note in read me.

SQL – Have added the backup file in the folder to check all the scripts at once.

Team No - D
------------
Student ID: 10612366, Name: Navin Kumar Singupuram
Student ID: 10605157, Name: Atul Krishna Sulli Radhakrishna
Student ID: 10612648, Name: Snehal Rajendrakumar Baviskar
Student ID: 10622824, Name: Sonavva Nandagaon

Git Hub Link
--------------
https://github.com/sonunandagaon/B9IS123_10612366_10622824_10612648_10605157_InformationSystems.git

Overview:
--------------
Ecommerce is simply the act of buying and selling goods or services online without requiring people to physically come to your business. Millions of people worldwide enjoy playing musical instruments, thus they search for the finest offers that will enable them to purchase their preferred instruments. The advent of internet technology has altered how people purchase for musical instruments, and many now choose to do their shopping online to save time and money. Here, we quickly examine the reasons why you should purchase musical instruments from our store online.
1. Easy and Convenient:
     It is simpler and more practical to purchase musical instruments from our store.
2. Reasonable Price:
     You can always find affordable rates at our music store. On a variety of musical    instruments, we are always pleased to offer discounts.
3. Variety:
    With our music store, you can quickly select the brand you want and compare it to others without having to put in a lot of effort.
    
Technologies and Concepts:
---------------------------------------
 Implementation Framework: 
1.	Sans Music Store is implemented on Visual Studio 2022 .Net 6 Framework using the MVC pattern.

Technology Concepts:
1.	Concepts such as css isolation, dependency injections, patterns.
2.	Web API services using CRUD operations 
3.	CSS key frames and bezier effect
4.	Sweet Alert Modal Popup for View Checkout in the 
5.	Razor pages
6.	Client side pagination suing JQuery	

 Middleware:
1.	Entity Framework using the database and code base first approach
2.	Ado.Net for web api services implementation
 Back-End:
1.	SQL Server 2019 v18.1.1
2.	Postman Tool for web services
 Scripting Languages:
1.	JQuery 
2.	CSS3 and Bootstrap, Html

Design Flow and Steps for User:
------------------------------------------
Step 1: Login Authentication using cookie and session authentication
-	Password is encrypted and the encrypted password in sql validates with the column and data.
Step 2:  Once customer login, following features is displayed.
	-	They can see the logo, piano css key frames with different Navbar options.
	-	Hero Section with Video, Css3 bezier effect of text.
	-	Product Section with different products fetched from the database.
	-	Code is written to save the data of the products as well in the database
	-	Last Section with more Bootstrap and Css
	-	Footer with different font awesome icons, css3 effects and bootstrap.
Step 3:  On click of the View details button below a product, it will navigate to the View     Product Screen where the details of the product will be displayed with ratings, price and also buttons with having Reserve and View Cart.
Step 4:  On click of the reserve button, the product will be added to the cart and will navigate to the product view cart
       - On reserve, the implementation of the create web api services is called and the products, details are get saved in the database.
Step 5: On navigation to the cart view page, the products are displayed in the grid using the get web api services.
Step 6: On click of clear button, the delete web api services are called and the data gets delete in the sql database.
Step 7: On click of “+” and “-” button, the update web api services are called and the data gets updated in the sql database.
Step 8: On click of view checkout button, the sweet alert modal popup JQuery is called to display a modal stating the product is reserved.

Attribution Report:
-------------------------
1.	Predefined functions are checked in the GitHub which are generated through the visual studio framework. (Commit No – 1 parent 80dae6b commit 9a95e6897467eb15d2ecaa20e4de29e2a4ce8e5b) by snavin
2.	Few Nuget Packages:
	-	EntityFramework Core
	-	Webapi Client
	-	Newton Soft Json
	-	SqlClient
	-	Configurations
	-	AspNetCore.Razor
	-	EntityFramework Tools
3.	Sweet Alert Modal Popup CDN
4.	Google Font CDN
5.	FontAwesome
6.	Images and Videos are taken from pixel, unsplash

Group D – Individual Contributions
----------------------------------------------
Member 1: 10612366 – Navin Kumar Singupuram
-------------------------------------
1.	Starting with creation of the skeleton of the project in .Net 6, added the predefined functions.
2.	To start initially, rewritten the layout page using bootstrap, css and few cdn’s to modify the Navbar to match the design and the theme of the idea.
3.	Have added the customized footer using Bootstrap 5 and Css 3, font awesome 
4.	Created a Login page using Razor along with styles in Login.cshtml view.
5.	Added the authentication and authorization logic in the home controller to implemented the session and cookie based authentication.
6.	Worked on the Migrations with the concept of code first approach and the database first approach using the Entity Framework as middleware to connect to SQL Server.
7.	After doing research on .Net 7 as css was not working, the new concept of .Net Framework known as .Net Razor Isolations was implemented.
        Ex: From Style.css, the css been moved to index.cshtml.css along with styles under the Razor View.
8.	Initially, have implemented the ajax call for post and delete method to fetch the data from db and use the web services.
9.	Removed the Startup file which has all the patterns, dependency injections, sql connections and moved it to the Program.cs
10.	 Have added several methods like AddSession, AddAuthentication,  AddControllersWithViews. AddRazorPages, UseStaticFiles, UseRouting , UseAuthentication, UseAuthorization in the Program.cs so the whole application can fetch the connections and work.
11.	Migrations been added to the authentication controller and fixed the home page cshtml
12.	Added logics to show products on screen in index controller (home page) from the database and also saving the data in the database along with client side pagination.
13.	 Fixed the product section logic to make the home page work.
14.	 Added the completed product detail implementation starting from the design, developing the login in the controller and showing the page perfectly.
15.	Consuming of the Get API method in the controller added for showing the product details
16.	Implemented the Get API service method to work with the features of the grid design on the view cart page.
17.	Updated all the views, pages throughout the application in the last with cleaning of the code.
18.	Sweet Alert Modal popup JQuery for the View Checkout of the products
19.	JQuery implementation on the view cart page to shown only the Navbar not the footer 
----------------
Member 2: 10622824 – Sonavva Nandagaon
---------------------------------
