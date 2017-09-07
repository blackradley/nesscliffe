Notes
===========

Development Pipeline
--------------
Localhost > Development Server > Staging Server > Live Server

* Development Server http://blackradley-insight-develop.azurewebsites.net and
  automatically updated from https://github.com/blackradley/nesscliffe/tree/develop 
* Staging Server http://blackradley-insight-staging.azurewebsites.net 
  automatically updated from https://github.com/blackradley/nesscliffe/tree/master
* Live Server http://insight.blackradley.com/
  updated by manually swapping with Staging.

Access to the development and staging servers restricted based on IP address.
http://ruslany.net/2014/04/azure-web-sites-block-web-access-to-non-production-deployment-slots/

Migrations
-----------
Migrations are enabled for the datacontext.

* Add-Migration NameOfTheMigration -Force
	
	Will scaffold the next migration based on changes you have made to your model since the last migration was created

* Get-Migrations

<<<<<<< HEAD

=======
>>>>>>> fdb15d4931e078cdc3c050c1a13c5718adaf59cb
* Update-Database -TargetMigration:"NameOfTheMigration"

Use Sql Server Management Studio to connect to the development database 

	Server: (localdb)\MSSQLLocalDB

Error Messages
-----------
* Apologise.
* Say what went wrong.
* Say how to resolve it.
* Be polite.
* The message should be worded so that the application accepts responsibility for the problem. 
