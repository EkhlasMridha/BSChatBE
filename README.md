# BS Chat App BE

This project was generated with .NET 5 .

## Database Setup

###### DB setup
* Download and install MS Sql server on your system by visiting [here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Ignore if you have already installed). 
* Download SQL server management studio also, if you don't have already installed [SSMS](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15).

###### Connect to database engine
After the installation open Microsoft sql server management studio and connect it to your database engine. For further instructions visit [Microsoft SSMS doc here](https://docs.microsoft.com/en-us/sql/relational-databases/lesson-1-connecting-to-the-database-engine?view=sql-server-ver15).

###### Importing database
* Click on `New query` on the toolbar of Sql server management studio. This will open a new script window.
* Copy the script of `script.sql` file (inside BSChatBE directory) on the script window.
* Now click on `Execute query`. This will create the database for the project.

## Project setup

###### Dowload Tools
Download visual studio from here [Visual studio 2019](https://visualstudio.microsoft.com/downloads/) (If you don't already have). Install it on your system.

###### Edit DB Connection String
* Go to BSChatBE => BSChat directory, open appsettings.json file.
* Find this section- 
`"ConnectionStrings": {
    "BSChatDB": "Server=<Server_name>;Database=BSChatDB;Trusted_Connection=True;MultipleActiveResultSets=True;"
  },`
* Enter database server name in the place of `<server_name>`.
Ther server name can be found on sql server management studio.
![server-name](https://github.com/EkhlasMridha/BSChatBE/blob/media/servername.png?raw=true)

###### Run solution project
* Now double click and run the `BSChat.sln` file with visual studio .
* Run the project with IISExpress by clicking on the IISExpress button on the toolbar of visual studio.


## Running BS Chat App

It needs to run both BSChatBE and BSChatFE project at the same time to make the project functional.
