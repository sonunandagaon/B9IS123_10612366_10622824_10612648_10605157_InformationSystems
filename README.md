# B9IS123_10612366_10622824_10612648_10605157_InformationSystems

* Login Credentials for Application : Username - navin , Password - 1234

* Note (Password base64 Hash): We have added the base64 hash encryption for login authentication can be validated by the User table in the database which was not included in the code during the presentation ------- Discussed with Paul in the class to add note in read me.

SQL BackUp file provided with stpes in order to restore it for the application.

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


SQL Restoration Process Steps: 
------------------------------
1. Go to Sql Server Management Studio and create a new Database : MusicEquipmentStore
<img width="524" alt="image" src="https://user-images.githubusercontent.com/114439647/208297704-77cb4094-a3c9-4873-a73f-94a2487e2e44.png">
2. Right click on the 'MusicEquipmentStore' database and click on Tasks, select Restore and select Database
<img width="960" alt="image" src="https://user-images.githubusercontent.com/114439647/208297844-404bc0f3-8880-410c-9310-54af79641289.png">
3. Select Device check box and click on three dots to select file
<img width="431" alt="image" src="https://user-images.githubusercontent.com/114439647/208302496-3c39cc26-a27b-4c59-af36-4e98bef0523f.png">
<img width="427" alt="image" src="https://user-images.githubusercontent.com/114439647/208297950-fc64d273-0be1-4ba8-b7c7-cb72e92d15e0.png">
4. Click on Add option and navigate to the folder where 'MusicEquipmentStore.bak' is saved.
<img width="473" alt="image" src="https://user-images.githubusercontent.com/114439647/208298015-adeaaa5f-0e48-47b2-bc85-2a9dfa03cd5d.png">
5. Select the 'MusicEquipmentStore.bak' file and click on 'OK' and again click on 'Ok' in the backup devices.
<img width="364" alt="image" src="https://user-images.githubusercontent.com/114439647/208298060-f7d6a704-04aa-414b-bca9-fdcc3f6d497e.png">
6. Navigate to the 'Options' and check mark the 'Overwrite the existing database(WITH REPLACE)' option and click on 'OK'
<img width="429" alt="image" src="https://user-images.githubusercontent.com/114439647/208298169-99fe4fdf-e006-452b-9bb0-6ca56d572599.png">
7. Database Restoration successful message will be displayed.
<img width="427" alt="image" src="https://user-images.githubusercontent.com/114439647/208303157-2a733131-a097-4f2e-a62f-073e34895413.png">
8. All the following table will be present in the Database.
<img width="174" alt="image" src="https://user-images.githubusercontent.com/114439647/208303186-201e2ce4-3478-40b1-ba4a-e9209876111a.png">


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
Member 1: 10622824 – Sonavva Nandagaon
-------------------------------------
* Initially as a team decided to user JSON data to show prodcuct related details for which added a JSON service,JSON data and a Javascript functionality to           fetch JSON data which later moved to database.
* Product Controller with pre defined funtions has been added to add methods which helped in consuming API methods and added a search functionality to search the     product.
* Database Context added with concept of ADO.NET and updated the connection string which helps in connecting database through controller.
* GetProductDetails, SaveProductDetails functionality added to save and fetch data from the database but later decided to move images to the folder.
* Ajax functionality to call GetProductDetails and then mapped to the index page.
* ProductTable model added with required attributed to push data to the View Cart page.
* Web API functionality was not working for which added a proper route configuration and services in Program.cs file.
* Implemented AddToCart functionality to store cart related details into the database with the help of ADO.NET approach.
* Added a Javascript functionality for the show password feature.
* CartViewModel, SmallCartViewModel, Category and Product models added in order to help seperation of functionality.
* In order to increase or decrease product item quantity in cart page, added Add and decrease methods in ProductCartController which consumes update API               method from the CartController.
* Update API service method in the CartController has been added in order to update cart details in the database. 
---------------------------------
Member 2: 10612366 – Navin Kumar Singupuram
---------------------------------
* To start initially, rewritten the layout page using bootstrap, css and few cdn’s to modify the Navbar to match the design and the theme of the idea.
* Have added the customized footer using Bootstrap 5 and Css 3, font awesome
* Created a Login page using Razor along with styles in Login.cshtml view.
* Added the authentication and authorization logic in the home controller to implemented the session and cookie based authentication.
* Worked on the Migrations with the concept of code first approach and the database first approach using the Entity Framework as middleware to connect to SQL         Server.
* Initially, as a team we decided implementing ajax calls for which have added post and delete method to fetch the data from db and use the web services.
* As discussed with team, Removed the Startup file which has all the patterns, dependency injections, sql connections and moved it to the Program.cs
* Added Authentication and Authorization techniques to the login page.
* Partially added Migrations to the authentication controller and fixed the home page cshtml.
* Added logics to show products on screen in index controller (home page) from the database and also saving the data in the database.
* Partially added the completed product detail implementation starting from the design, developing the login in the controller and showing the page perfectly.
* Consuming of the Get API method in the controller added for showing the product details
* Implemented the Get API service method to work with the features of the grid design on the view cart page.
* Sweet Alert Modal popup JQuery for the View Checkout of the products.
* JQuery implementation on the view cart page to shown only the Navbar not the footer.
------------------------------------
Member 3: 10612648 - Snehal Rajendrakumar Baviskar
------------------------------------
* Initially added some css and html changes to implement navbar in hero page and also added.
* Data Access Layer added and GetProductById method added to fetch product details from the database
* Was not able to access Data Access Layer, And did some research on a start up class hence added a startup class with configuration services to make it work.
* Other team member added product context class and with the product database model have updated few more attributes including rating, price etc. To show more         product related information to the user.
* To connect database with the API controller, to fetch cart related details have used ADO.NET framework have added a proper connection string.
* With the help of .NET framework predefined functions have added a Product Controller, And implemented a business logic for the Get Method which is GetCartItems     which is used to fetch Cart Details from a specific user.
* Created a Cart Model and added required attributes to display Cart details. 
* Added a razor page views for Categories and CartProduct along with data binding feature from the controller with the help of models to display product in the       cart details and categories.
* Added a css styling and bootstrap changes for the views Categories and CartProduct to make it more user friendly.
* Created a view for the login with the help of razor view and some html.
* Functionality to show/hide password whenever user clicks on the eye icon so that user can view his password.
* Added a method in the product cart controller 'AddToCart', To consume POST API method which is create in the cart controller.
--------------------------------------
Member 4: 10605157 - Atul Krishna Sulli Radhakrishna
--------------------------------------
* Added HTML code changes for product content to show details in the Home Page.
* Added Product model with required attributes of product details which helps in binding data to show in the Home page.
* Code changes has been added to index method of the product controller to get all the details from the database. 
* Initailly group has decided to have a service for performing CRUD operations and for the same reason have added a service called Product Service which contains   Interfaces that helps in dependency injection.
* For the Product Service have implemented required methods which are GetProductsDetails and SaveProductDetails which helped in saving the product details and       getting the product details from database.
* Initially as a team we thought of saving product related images into database by using file upload functionality for which have added file upload model with       required attributes.
* Added migration script for Product_table and also fixed the Git Conflict
* Added a CART Model which helps in binding data to show product details in the cart view page.
* Added modifications to the view and model for the login page to resolve UI issues.
* Client side Pagination has been added in order to make page more user friendly when there are multiple products.
* Added a delete API method in Cart Controller class.
* A method called ClearCart added in product cart controller to consumer delete API method for clear the cart items functionality which is specific to the user.
* Store Encrypted password in database implemented base64 hashing technique.
