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


The inventory deduct values like this mention below from the stock the items used in the product/dish .

-zinger burger

| Incredients                | Quantity 
___________________________________________
| chicken flay               | 125 gm   
| salt                       | 1 gm     
| chinese salt               | 1 gm     
| white mirch (white chilli) | 1 gm     
| mastard powder             | 1 gm     
| sauce                      | 1 gm     
| meda                       | 250 gm
| bread crum                 | 250 gm
| baking powder              | 1 gm
| egg                        | 1
| corn flour                 | 2 gm
| milk                       | 8 gm
| bun                        | 1
| mayoneze                   | 1 gm
| ketchup                    | 1 gm
| salad                      | 1gm 

-beef burger

| Incredients                | Quantity
___________________________________________
| qeema (minced meat)        | 500 gm
| salt 			     | 1 gm
|lahsan (garlic) (pissa hua) | 2gm
|white chilli                | 2gm
|black chilli                | 2gm
|tomato paste                | 4gm
|ketchup                     | 4gm
|mastard paste               | 2gm
|chinese salt                | 2gm
|sirka (Vinegar)             | 4gm
|soya sauce                  | 4gm
|butter                      | 4gm
|egg                         | 2
|milk                        | 8gm
|double roti ka chora (bread crumb) | 1 bowl
|cooking oil                 | 20gm

-club sandwich

|Incredients           | Quantity
_________________________________________
|salt 		       | 1gm
|white pepper powder   | 1gm
|black pepper powder   | 1gm
|soya sauce 	       | 2 gm
|Lemon juice 	       | 2 gm
|Mustard paste 	       | 1gm
|Ginger garlic paste   | 1gm
|oil                   | 2 gm
|bread slices          | 1
|cheddar cheese slice  | 1
|egg                   | 1

-chicken sandwich

|Incredients                            |Quantity
______________________________________________________
|chicken 				| 80 gm
|salt 					| 1 gm
|white cayenne pepper (white red mirch) | 2 gm
|mastard powder 			| 1 gm
|meda 					| 4 gm
|butter 				| 2 gm
|milk 					| 250 gm
|bread slices 				| 1
|ketchup 				| 10 gm

-bbq sandwich

|Incredients 			| Quantity
__________________________________________________
|onion 				| 65 gm
|sirka (Vinegar) 		| 4gm
|diced celery (ajwain) 		| 1 gm
|chili powder (mirch powder) 	| 2 gm
|garlic clove (lahsan ki long) 	| 1
|butter 			| 2 gm
|salt 				| 1 gm
|ketchup 			| 1 gm
|brown sugar 			|  4 gm
|pepper (kali mirch) 		| 1 gm
|chicken 			|  70 gm
|bun 				| 1
|salsa 				| 40 gm

-chicken burger

| Incredients			| Quantity
______________________________________________
|chicken qeema 			| 250 gm
|bread slice 			| 1
|egg 				| 1
|mastard paste 			| 3 gm
|black mirch 			| 3 gm
|salt 				| 1 gm
|mayoneze 			| 1 gm
|oil 				| 40gm
|cheddar cheese slice 		| 1
|butter 			| 2 gm
|salad 				| 1

-broast

| Incredients 			| Quantity
|chicken 			| 500 gm
|sirka 				| 50 gm
|soya sauce 			| 6 gm
|chinese salt 			| 2 gm
|black mirch 			| 1 gm
|salt 				| 2 gm
|oil 				|  40 gm
|meda 				| 250 gm
|corn floor 			| 4 gm
|rice floor 			| 4 gm
|white red mirch 		| 2 gm
|lahsan 			| 2 gm
|egg 				| 1

