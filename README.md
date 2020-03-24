﻿# Assignment-1
This Website Provide Computer Hardware Products to Customers. From this website customers can purchase various computer hardware parts like Rams, Motherboards, CPU coolers and many more.
It has to options on nav bar one is for adding products and one for manufacturers. Link to the website with working database.
- **Azure Link**: https://protoncomputers20.azurewebsites.net
# Assignment-2 Part-1
1. Used Identity.sql script to create the necessary ASPNET Identity tables in database.
   - Configured Identity in Startup.cs.
   - Changed DbContext class so it inherits from IdentityDbContext.

2. Used Authentication 
   - Register and Login show when the user is anonymous. Done
   - Register and Login are replaced in the header by the username and Logout when the user is authenticated. Done 
   - Created an account with these credentials:
     - marie@gc.ca / Test123$
   - Only authenticated users can now add, edit and delete data.
   - Only anonymous users can view the list of data but cannot see the Create, Edit, or Delete links.

3. Added Social Authentication with **Google**.
   - Google Authentication Working on Both Local and Online Environment.
   - Stored All the Api Keys in **appsettings.json** file rather than inside the C# code.

4. Github
   - Used **.gitignore** so the Packages folder does not get included in your online repository.

5. Azure
   - Publish to the site to Azure or any other web server that supports ASP.NET and SQL Server. Include this link in your README.md file.
     - **Azure Link**: https://protoncomputers20.azurewebsites.net
- Bonus
  - Added **Twitter** Login on Both Local and Online Environment.

# Assignment-2 Part-2

#### Before Running the Project.
1. Add Reference of the Main Project into UnitTest solution.
   - Right Click on Dependencies then Add Reference as shown in Image Below.
![Step 1 Image](wwwroot/screenshots/Step1.png)
2. Select the Project from the list and click OK.As shown in Image below.
![Step 2 Image](wwwroot/screenshots/Step2.png) 
3. If you get these types of errors.
![Step 3 Image](wwwroot/screenshots/Step3.png)
Then Delete the Obj folder from sub-dir folder. 
![Step 4 Image](wwwroot/screenshots/Step4.png) 
### Summary of Assignment-2 Part-2
1. Created a Unit Testing project within my main project solution and created a HomeControllerTest.
   