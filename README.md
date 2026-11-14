## Technologies Used

	- **C#**: Language

	- **Blazor**: Front end framework

	- **MongoDB Atlas**: Cloud database 
	
## NuGet Packages

	- **MongoDb.Driver**: Allows program to connect to MongoDB

	- **DotNetEnv**: Loads .env key-value pairs into environmental variables

## Prerequisites (download these)

	- Git

## FIRST TIME BUILD NOTES
	
	1. Run "dotnet restore" to obtain the NuGet packages.

	2. Populate your .env with
		- MONGODB_CONNECTION_STRING=your_connection_string
		- MONGODB_DATABASE_NAME=your_database_name
# GitHub Rules

	- NEVER push to main

	- Branch names should be lower-dash-case

	- Branches should be named action then name.

		- Examples are feature/**name**, bugfix/**bug**, etc.

# GitHub Instructions

1. git switch -c "branch/name"
2. git add "file"
3. git commit -m "what changed"
4. git push