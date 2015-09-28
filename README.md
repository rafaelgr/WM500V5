# WM500V5
A .net solution to communicate to WM500 terminals via USB

Based on the program demo included in the WM500V5 terminal, this solution try to arrive to communicate with that terminal via usb from a NODE application.

You can install and test the application

npm install wm500v5

To run 

node index.js

By default (see config.json) a server starts in localhost:8090 and you can access the API 

GET http://localhost:8090/terminal/read-terminal-number
[Reads the terminal number a sends it to the client]

GET http://localhost:8090/terminal/records
[Reads all records a return them as an arry of json objects with two fields (tag an stamp)]

DELETE http://localhost:8090/terminal/records
[Delete all records in terminal]

POST http://localhost:8090/terminal/set-date-time
[Sets date and time from the server to terminal (PC DateTime)

Have fun !!


