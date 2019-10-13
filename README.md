# Foodies (POS + Inventory)

Foodies is a point of sale and inventory management system which takes cares of all the sales , inventory and stock operations .
The app is design on .NET frame work 4.5 using C# .NET with a sql database all the records is been saved in the sql database foodtime.mdf located in the Data folder with in the project . The Databse .sql file for the project can be found in the repository in the folder FoodiesDBSqlFile .You can copy the file and then excute it in the sql server for checking the app.

This app perform all the task needed for a fast food restuarent it has a cashier form for selling the products and printing the bill functionaltity .The App required login credentials for login to use the application and then authenticate the valid user for using the app.the cashier form is for selling and selecting the products for sale.The App includes inventory functionality which is responsible for deducting the current stocks items used in a product via method on pressing the Done Transaction button currently the inventory can only minus the stock for 6 defined products .

The inventory form enables you to search the current products , categories , stock items , viewing the todays , weekly , monthly and annual sales charts and the first tab you could see the number of invoices , orders , customers, deleted invoices , current present stock , stock at the start of new date , stock items , current products count , current categoris count , app users and current year annual sales.

The app includes the stock form creating new stock , updating and deleting the stocks items.

The App includes user form for only the admin .whi can view and manage the app users.

The app includes the invoice search form for searching the invoices .Cancel invoice form for canceling the invoices .Delete invoice form for searching cancelled/Deleted invoices and edit invoice for the editing the eist bill if there is an error which will also been updated in the database .

The app includes prices form for searching the prices of the products .

The app also includes the Create Category and Manage category form for creating and managing categories.

The app also includes the Create Products and Manage products form for creating and managing products.

The App includes garphic cahrt represntation charts form of daily , weekly , monthly and annual sales form which shows the sales in the bar charts .

The app includes the export to excel form by using this you can export the excel file of your bill , customers , orders , stocks , catgeories, products information .The App will automatically create a folder in the C directory with Foodies name in which your all excel files would be saved .

The app includes and About form showing the app info and official site for app hyperlink.

The App also includes Sales Summary form which gives you the daily , weeekly , monthly and annual sales details in the numberic form and also shows the total annual sales of products in numbers .

The app also includes timer for checking the stock if a stock is zero it will open a new form for you to update a stock item which is now zero in quantity .Tha app also uses another timer for checking that whether the app is activated or not ?

The activation form in the app activates the app by entering unique key .The activation is done via firebase thorugh internet .you cannot used a single key for multiple Pcs because the app check the key whether its uses before in anotner pc or not ?.This is all done by geting the data from the firebase and then reading it .   

More features will be added in the app in near future as it is still under development .
