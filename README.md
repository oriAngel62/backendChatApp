# backendChatApp
This is Stage two of Server ServerChat task in advance 2 course.

The task was coded by Avia Hadad, Orri Angle, and David Gurovic.
The project main repositry can be found at:

https://github.com/oriAngel62/backendChatApp.git

All 3 has contributed to the project via git & github version control
management system,
contributions can be tracked with git log.

This stage of the project focuses on building a back end of a Chat'
resembling a real server from social media tool such as Whatsupp, Discord, Facebook Chat etc'

The project is written with Visual Code Framwork with ASP.NET Entity
We worked in a Model View Controller Pattern.

We created a http Server and used Maria DB to negotiate with the DataBase
the server enable us to add new users and store them localy in DB. The server 
return the information from api request in json format. We combined the React 
part from level 1 and changed the hard coded staff.
We also added Signal R whos enable us to commiounicate with other servers in 
a real-time, so when you want to chat with somone, that someone see it immeditaly. The Functions are a -synch because
we wanted the app to run flow and we put await if it must stop before continue,
as for example- getting the user log in details.
Steps to run the project:
*open visual studio
*Clone the project to your PC (the project is in the main branch- just copy the url from git)
*download MariaDB :

download -https://mariadb.org/

packages - 
Install-Package Pomelo.EntityFrameworkCore.MySQL -Version 6.0.1
Install-Package Microsoft.EntityFrameworkcore.Tools -version 6.0.1

VisualStudio -> search -> package maneger -> ( a console window open) -> write: Add-Migration "nameOfYpurChoise"  (to remember - compilation)->
-> write: Update-DataBase  (to remember - sync)  -----  we got DB

how to play with it:
open prompt - search in windown : "MySQL Client (MariaDB ... )" -> then password
use PomeloDB (name of the db);   - to open DB
(open the table "user") SELECT * FROM user;
