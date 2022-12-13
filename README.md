# SE-FinalProject
Instructions for connecting to the database
1. Execute SQL code in SQLQuery-SE-Final.sql file.
2. In App.Config file, enter the server name and database name in the 2 variables SERVER_NAME and DB_NAME  
<add connectionString="Data Source=SERVER_NAME;Initial Catalog=DB_NAME; Integrated Security=true" 
			 name="MyConn" providerName="System.Data.SqlClient"/>
3. After that, run windows form application in your Visual Studio
       
