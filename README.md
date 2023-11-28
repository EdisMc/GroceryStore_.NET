# Grocery Store 

![Screenshot 2023-11-28 204117](https://github.com/EdisMc/GroceryStore_.NET/assets/92871901/45b4be13-bdcb-4a08-bbef-96f950f660ca)

## General Information 
"Grocery Store" is a desktop application developed for grocery store management - adding products, selling products, history of sells etc. 
Used technologies are: C# (.NET Framework), Windows Forms and SQL.

## Functional Requirements
The information system provides the following capabilities:
  -Order and recording of goods in a grocery store;
  -Addition/removal of new products;
  -Modification of information for an existing product (editing its attributes);
  -Filtering of products by specified categories;
  -History of completed sales.

There are 2 types of users: administrator and seller. They should perform the following operations:

Administrator:
  -Add, edit, and remove a product;
  -Sort products by categories (fruits, vegetables, meat products, dairy products, beverages);
  -Add, edit, and remove a seller;
  -Add, edit, and remove product categories;

Seller:
  -Select products from the list (enter quantity for each product) and add them to the basket;
  -Sort the list of products by categories;
  -Complete a sale;
  -Generate a report (history) of made sales, including information on invoice number, seller's name, sale date, and total amount payable;

The system should store data (in the database) for:
  -Products (Products);
  -Categories (Categories);
  -Sellers (Sellers);
  -Invoices (Bills).

## Non-functional Requirements
  -A login form is used by all users to access the system (system access is granted after entering a username and password);
  -Standard operations (data entry, correction, and deletion) are implemented in each table in the database;
  -Generation of necessary reports: both on-screen and for printing;

## Database Design - ER Diagram

![44442](https://github.com/EdisMc/GroceryStore_.NET/assets/92871901/5eed36a4-a2e9-46a8-8272-14a80e8ef70a)






