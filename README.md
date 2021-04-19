# Origin Coding Challenge

# 1.The User insurance creation:
**1.1 As the challenge states, there must be a user input, with the challenge described data. For that, this solution instates a Contract model. The model contains all of the challenge-required data and some other properties that make the solution more "user-friendly".
**1.2 Risk Questions: as a normal insurance tool would support several different questions, the risk questions were created dynamically, registered into the database. This makes it possible to add new questions, activate questions, or deactivate questions. The challenge uses only 03 questions, however, if there's a desire to add more questions, the solution is ready to deal with that new number.

# 2. Validations:
*2.1 Challenge rules: the values that were defined by the challenge are all validated by the DataAnnotations properties of the Contract Creation Data Request;
*2.1 Challenge business logic: the challenge's business logic is implemented and validate within the solution's classes.

# 3. Structure:
*3.1 Service: contains the controllers of the API. Receives data accordingly to the challenge's goals, send it to the next down layers for processing, and returns the results of the actions;
*3.2. AppService: responsible for changing the format of the data between the Service View format (ViewModels) and the Domain Data format. This enables a low level of dependency between the layers of the solution;
*3.3. Domain: the layer that contains the business logic of the solution. It receives data from the AppService (as data models) and the Infra Data (as data models). This makes it "blind" to the other layers, allowing a low level of dependency between the data format and the business logic implementation;
*3.4 Infra Data: the layer responsible for dealing with the solution's data and data access tools. It serves the Domain layer without "knowing" how the data will be transformed later;
*3.5. Infra IoC: the layer for registering the dependency injection services. It is the only one that has access to all of the projects' layers. This makes it possible for a low level of maintainability, in case there's a need for changes in the project. Also, it organizes the way and the order of the services' registrations.

# 4. Database:
*4.1 The database server for this project is a MySQL Server 8.0.22;
*4.2 Migration: the project already contains the needed migrations and the solution will create the database if there's a server connection;
*4.3 Connection: this solution was constructed using Environment Variables. This makes it simple to test with Docker or Windows. The following Environment Variable should be created/set
ORIGIN_ENVIRONMENT__CONN_STRINGS__ORIGIN_MAIN_DATABASE
with value
server=127.0.0.1;port=3306;database=dbOriginChallenge;uid=host;password=13881010.

# 5. Testing: the tests were implemented to check the API's endpoint's consistency. So, there are 03 types of check:
*a) Load: checks the capacity of the solution to deal with several requests during a small timespan;
*b) Business logic: tests the results of the requests for correct and wrong data requests;
*c) Response types: checks if the expected response types are correctly implemented for the successful or failed request process.

# 6. Code: this solution was built using C# as a language with the .NET Core 3.1 framework. For testing, there's the possibility of using Docker. However, for debugging, the easiest way is to have the Visual Studio installed with the .NET Core 3.1 framework setup. The ORM for this solution is the Entity Framework Core. For testing, some Mocked methods were created. But, for the controller test, the XUnit was used as the base framework.
