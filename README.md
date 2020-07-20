# High Level Architcture
![Architecture](https://user-images.githubusercontent.com/9402322/85918256-a4095600-b893-11ea-9b4f-4b71efda56aa.png)  
Image above adapted and edited from [online](https://kasvith.me/posts/how-we-created-a-realtime-patient-monitoring-system-with-go-and-vue/)  



# Current progess:

| Part | Task | Remark |
| --- | --- | --- |
| SensorNode (VB.Net)|  Migrate from NetworkStream to Socket.IO | Done
| | Random(), BodyTemperature, HeartRate, BloodPressure | Done
| | Use JSON to combine Ramdom data & patientName and sent via Socket.IO | Done
| | Accept unlimited* patient monitoring using ForLoop & Array (Dynamic coding)| Done
| Gateway (Node.js) | Retrive data using Socket.IO  | Done
| | Implement API using Express.js Route ( app.get '/' )| Done
| | Implement Database using Redis to store patient information in JSON  | Done
| Frontend (html/javascript) | Simple realtime monitoring using console.log  | Done
| | Retrive Webpage, JSON from API route '/' | Done
| | Realtime graph | In progress  



# Steps to run the program:

1. Clone our program from github (master branch)

2.  Run [redis-server.exe ](https://dingyuliang.me/redis-3-2-install-redis-windows/)   

3.  Run app.js  
    *In case nodejs complaining some modules not found:-  
    npm install redis   
    npm install socket.io   
    npm install express          
    
4.  Run Module1.vb, now the app.js will show client is connected  
    *In case vb complaining some variable is not defined, install package(s) below using [NugetPackageManager](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio)  
    [H.Socket.IO](https://github.com/HavenDV/H.Socket.IO)  
    [Json.NET]( https://www.newtonsoft.com/json)  

   
5.  Now proceed to send data with sensorNode (insert number of patient to be monitored)

6.  Open any browser, type http://127.0.0.1:55555/ (lima 5)

7.  You should be able to see a webpage  
    Press F12, Select console tab, to view the patient data in real time  
    Browse http://127.0.0.1:55555/data (lima 5) view the API return value, that is JSON

8.  That's it.


# Screenshot(s) of the program:

![image](https://user-images.githubusercontent.com/9402322/85916606-f5f6af80-b884-11ea-9cfc-9833ad34165d.png)  
Left : Gateway (Node.js)  
Right : SensorNode (VB.Net)

Program will ask user to enter the number of patient to be monitored.  
After getting the numbers, program will then ask names for each patient  
Then only will initate Random() to send the patient infromation 

![image](https://user-images.githubusercontent.com/9402322/85916610-fa22cd00-b884-11ea-8cb0-456065700687.png)  

Above : Frontend realtime dashboard   
Bottom : API (Express route) 

The dashboard will access the JSON (patient information) via API '/data'  

![image](https://user-images.githubusercontent.com/53253460/87915296-8f8c3800-caa4-11ea-98e5-64239f312327.png)
![image](https://user-images.githubusercontent.com/53253460/87915296-8f8c3800-caa4-11ea-98e5-64239f312327.png)
![Uploading image.png…]()
![image](https://user-images.githubusercontent.com/53253460/87915543-e4c84980-caa4-11ea-82c2-6a53c67c6a47.png)



![Uploading image.png…]()


# Acknowledgement

LEE ZHEN YU   (Team Lead)  
TAN KHIM HUANG   
TEH ZHEE KIAN  
Muhammad Norhadri Md Hilmi (Lecturer)
