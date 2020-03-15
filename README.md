# Assignment-1
This Website Provide Computer Hardware Products to Customers. From this website customers can purchase various computer hardware parts like Rams, Motherboards, CPU coolers and many more.
It has to options on nav bar one is for adding products and one for manufacturers. Link to the website with working database.
- Azure Link: Visit https://protoncomputers20.azurewebsites.net
# Assignment-2a
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