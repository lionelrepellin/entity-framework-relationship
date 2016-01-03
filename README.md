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

### That it is not

No design pattern or architecture design can be found here - do not imitate this project - it's just a try to learn EF relationships.

### Copyright and license

Code released under [the MIT license](https://github.com/twbs/bootstrap/blob/master/LICENSE).