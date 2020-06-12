Above are just the skeleton of our assignment, the base code is based on the previous Guess Game assignment in Distributed System Course. Seed mtching, and score update, etc is removed for code simpiicty.   

We will be having three parts:-  
1. backened.js(backend) will be based on Nodejs + redis   
2. Module1.vb (frontend) will be based on VB.net  
3. API (TO BE DONE)  

Steps:   

1. Download nodejs, extract, install the following:  
npm install redis   
npm install socket.io   
npm install express  

2. Download redis 3.2.100   
https://dingyuliang.me/redis-3-2-install-redis-windows/    

comamnd to run:    
node backend.js    

Because SocketIO is based on JS, we found our there is a ported SocketIO library for .NET (VB, C#, C++) here    
https://github.com/HavenDV/H.Socket.IO    

JSON Library for .Net  
https://github.com/JamesNK/Newtonsoft.Json  

MQTT  
http://TO BE FOUND/  

Above library can be insalled in Visual Studio using Nuget Package Manager    
https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio    


Result of runnning the skeleton code using VB with H.Socket.IO library.  
![Skeleton](/skeleton.png)  

