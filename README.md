# High Level Architcture
![Architecture](https://user-images.githubusercontent.com/9402322/85918256-a4095600-b893-11ea-9b4f-4b71efda56aa.png)  
Image above adapted and edited from [online](https://kasvith.me/posts/how-we-created-a-realtime-patient-monitoring-system-with-go-and-vue/)  



# Current progess:

| Part | Task | Remark |
| --- | --- | --- |
| SensorNode (VB.Net)|  Migrate from NetworkStream to Socket.IO | Done
| | Random(), BodyTemperature, HeartRate | Done
| | Use JSON to combine Ramdom data & patientName and sent via Socket.IO | Done
| | Accept unlimited* patient monitoring using ForLoop & Array (Dynamic coding)| Done
| Gateway (Node.js) | Retrive data using Socket.IO  | Done
| | Implement API using Express.js Route ( app.get '/' )| Done
| | Implement Database using Redis to store patient information in JSON  | Done
| Frontend (html/javascript) | Simple realtime monitoring using console.log  | Done
| | Retrive Webpage, JSON from API route '/' | Done
| | Realtime graph | Done 



# Steps to run the program:

1. Clone our program from github (master branch)

2.  Run [redis-server.exe ](https://github.com/MicrosoftArchive/redis/releases/download/win-3.2.100/Redis-x64-3.2.100.zip)   

3.  Run app.js  
    *In case nodejs complaining some modules not found:- 
![image](https://user-images.githubusercontent.com/53253460/87931033-af7b2600-cabb-11ea-9251-e970b37ee3b0.png) 
    
    open CMD and insert the code below:   
    -->npm install redis   
    -->npm install socket.io   
    -->npm install express          
    

4.  Run Module1.vb, now the app.js will show client is connected  
    *In case vb complaining some variable is not defined, install package(s) below using 

    [NugetPackageManager](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio)  
    [H.Socket.IO](https://github.com/HavenDV/H.Socket.IO)  
    [Json.NET]( https://www.newtonsoft.com/json)  

   
5.  Now proceed to send data with sensorNode (insert number of patient to be monitored)

6.  Open any browser, type http://127.0.0.1:55555/ (lima 5)


7.  You should be able to see a webpage  The patient will now shown in a graph presentation, each patient has its own graph  
    -->Press F12, Select console tab, to view the patient data in real time  
    Browse http://127.0.0.1:55555/data (lima 5) view the API return value, that is JSON
![image](https://user-images.githubusercontent.com/53253460/87932747-9cb62080-cabe-11ea-9c9f-f4a749a75492.png)
8.  That's it.


# Screenshot(s) of the program:

![image](https://user-images.githubusercontent.com/53253460/87922080-0bd74900-caae-11ea-9482-49d23b9601e4.png)
Left : Gateway (Node.js)  
Right : SensorNode (VB.Net)

Program will ask user to enter the number patient to be monitored.  
After getting the data, program will then ask names and age for each patient  
Then only will initate Random() to send the patient infromation 

![image](https://user-images.githubusercontent.com/53253460/87923761-8a34ea80-cab0-11ea-85f8-dcda81da44b3.png)
Above : Frontend realtime dashboard   
Bottom : API (Express route) 

The dashboard will access the JSON (patient information) via API '/data' 


By displaying data in this way it can also highlight trends, help us want to make a comparison and show a key relationship to inform others.
![image](https://user-images.githubusercontent.com/53253460/87924874-14318300-cab2-11ea-8ca5-a1ca4efc6c14.png)
![image](https://user-images.githubusercontent.com/53253460/87924989-3925f600-cab2-11ea-9595-0008b1aa7d5c.png)

# Benefits of using Graph in Healthcare

• Why do we want to have graph as data model?       
• Some of graph benefits
	
-->Simple use, immediate results.        
-->The chart allows to represent a lot of various information in the same diagram        
-->Fast query over multi-hop relationships	        
-->Data visualization and more easier to understand and only key information is presented.      

# Flowchart

![image](https://user-images.githubusercontent.com/53253460/87938498-40a4c980-cac9-11ea-81f1-417703168d0c.png)


# Acknowledgement

LEE ZHEN YU   (Team Lead)  
TAN KHIM HUANG   
TEH ZHEE KIAN  
Muhammad Norhadri Md Hilmi (Lecturer)
