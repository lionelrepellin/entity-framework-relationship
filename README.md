Entity Framework relationships with Fluent API
===

### What is it ?

Just some examples of relationships (one-to-one, one-to-many and many-to-many) with Entity Framework 6 Code First and Flent API

This is the database diagram :

![Database diagram](https://github.com/lionelrepellin/entity-framework-relationship/blob/master/database-diagram.png "Database diagram")

### Points of interest

- store all SQL queries in a log file
- disable lazy loading - may improve performance
- use a context initializer to insert data in the database before playing
- composite keys (for loan)
- many relationships tested to retrieve data
- enum are stored / retrieved
- inheritance (Table per Hierarchy) is implemented with library items (Discriminator column)
- primary key and foreign key naming convention
- configurations are moved into ***Configuration.cs files
- example of a stored procedure mapping
- create index on single and multiple columns
- entities properties are now 'private set'
- entities status are attached and added / modified to the context
- generic repository added
- use convention to rename the Discriminator property on the fly

### Automatic code based migration

- see [this article](http://rdonfack.developpez.com/tutoriels/dotnet/entity-framework-decouverte-code-first-migrations/ "Entity Framework Code First Migration") for more informations
- what to do in order :
    1. in Package Manager Console (for EF.DAL project) : **Enable-Migrations**
        - **Configuration.cs** file will be created in Migrations folder
        - **TIMESTAMP_InitialCreate.cs** file represents all you database
    2. made some changes in your model (add PageCount property in Book.cs)    
    3. now enter: **Add-Migration** *AddColumnBookPageCount* (describes your changes) in Package Manager Console to generate the differential
        - a new **TIMESTAMP_AddColumnBookPageCount.cs** file has been created
        - you can also add some SQL code in this file
    4. update Context.OnModelCreating method
        - sets the database initializer to use MigrateDatabaseToLatestVersion 

### That it is not

No design pattern or architecture design can be found here - do not imitate this project - it's just a try to learn EF relationships. This example does not follow the standard database naming convention, [see an example here](http://stackoverflow.com/questions/3593582/database-naming-conventions-by-microsoft)

### Copyright and license

Code released under [the MIT license](https://github.com/twbs/bootstrap/blob/master/LICENSE).