# DatabaseStressTestingTool 

Application used for performing stress tests on SQL and NOSQL databases.
It launches multiple processes in parallel that query MongoDB and SQLServer, simulating stations.

The MongoDB server must run locally on port 27017 (default).
the connection string for SQLServer is editable and must be set following the default model.

SQLServer Database -> WIP_Test [to edit it modify the main method of the Program class which is in res SQLServerThread SQLServerThread and the method button1_Click of class Form1]
MongoDB Database -> WIP [to edit it modify the main method of the Program class which is in res MongoThread MongoThread]

To change the queries executed on SQLServer modify the main method of the Program class which is in res\SQLServerThread\SQLServerThread
To change the queries executed on MongoDB modify the main method of the Program class which is in res\MongoThread\MongoThread

Pressing the getResults button will produce a text file with the average response times for each type of query for each DBMS.
