
'Changelog 28 June 2020
'Remove blood presure 
'Remove some comment 
'Add more realistic heart rate generator 

'Changelog 27 June 2020
'Code cleaning, removed commented code block
'Added some comments

'Changelog 26 June 2020
'#Issue8: Reusing ONE random generator code for more than one patient (output)
'Added For loop on asking how patient to monitor
'Added For loop on JSON Serialisation
'Moved Data Generator to a function, called RandomGenerator()
'Create sensorNode(), and put the main function here, leaving Main() clean.
'Code cleaning 
'Removed Case ("1.-open 2.-send 3.-close 4.-quit "), replaced with  ("Enter the number of patient u would to monitor:") 
'Removed SendAlready (), OpenConnection(), CloseCOnnection() as Socket.IO is an event-driven program, not using anymore

'Changelog 25 June 2020 11PM
'#Issue2&3 : Using JSON, and parsing JSON with Socket.IO
'Removed some unused code (previously commmented in branch issue#4)
'Install Newtonsoft.Json Library using NuGet Package Manager

'Changelog: 25 JUNE 2020 12PM
'#Issue4 : Migrate to socket.io
'Install H.Socket.Io by going to solution explorer, right click References, then manage NuGet Packages.



Imports H.Socket.IO
Imports Newtonsoft.Json



Module Module1

    Dim client As SocketIoClient = New SocketIoClient()         'Global var for Socket.IO

    Sub Main()

        client.ConnectAsync(New Uri("http://127.0.0.1:55555"))
        sensorNode()

    End Sub

    Public Class PatientClass                                              'JSON Classs

        Public Name As String
        Public BodyTemperature As String
        Public HeartRate As String


    End Class





    Function RandomGenerator() As String

        Dim temp As Double
        Dim tempSTR As String

        Dim random As New Random

        temp = random.NextDouble() * (40.0 - 37.0) + 37.0                         'patient body temperature generator from 37 to 40 (celsius)
        temp = Math.Round(temp, 1)
        tempSTR = CStr(temp)
        Threading.Thread.Sleep(500)                                               '1 second cycle
        RandomGenerator = tempSTR                                                  'Return as tempSTR 

    End Function
    Function RandomHeartRateGenerator(ByVal age As Integer) As String

        Dim heartRate As Integer
        Dim heartRateSTR As String

        Dim random As New Random

        If (age < 30) Then

            'for patinet who age below 30 heart rate will generate from 98 to 166 
            heartRate = random.Next(98, 166)

        ElseIf (age >= 30 And age < 35) Then


            'for patinet who age between range 30~35 heart rate will generate from 95 to 162 
            heartRate = random.Next(95, 162)

        ElseIf (age >= 35 And age < 40) Then


            ''for patinet who age between range 35~40 heart rate will generate from 93 to 157
            heartRate = random.Next(93, 157)

        ElseIf (age >= 40 And age < 45) Then


            'for patinet who age between range 40~45 heart rate will generate from 90 to 153 
            heartRate = random.Next(90, 153)

        ElseIf (age >= 45 And age < 50) Then


            'for patinet who age between range 45~50 heart rate will generate from 88 to 149
            heartRate = random.Next(88, 149)

        ElseIf (age >= 50 And age < 55) Then


            'for patinet who age between range 50~55 heart rate will generate from 85 to 145
            heartRate = random.Next(85, 145)

        ElseIf (age >= 55 And age < 60) Then


            'for patinet who age between range 55~60 heart rate will generate from 83 to 140
            heartRate = random.Next(83, 140)

        ElseIf (age >= 60 And age < 65) Then


            'for patinet who age between range 60~65 heart rate will generate from 80 to 136 
            heartRate = random.Next(80, 136)

        ElseIf (age >= 65 And age < 70) Then


            'for patinet who age between range 65~70 heart rate will generate from 78 to 132 
            heartRate = random.Next(78, 132)

        ElseIf (age >= 70) Then


            'for patinet who age above 70 heart rate will generate from 75 to 128
            heartRate = random.Next(75, 128)

        End If

        heartRateSTR = CStr(heartRate)

        RandomHeartRateGenerator = heartRateSTR


    End Function




    Sub sensorNode()  'previosuly known as sendData()

        'Get number of patient to monitor
        Dim num As Integer
        Console.WriteLine("Enter the number of patient u would to monitor:")                           'ask for patient name
        num = Console.ReadLine()

        Dim array(100) As String                                                                      'declare array
        Dim count As Integer = 0                                                                      'counter for array         

        Dim array2(100) As Integer

        For index As Integer = 1 To num                                                               'for loop until reach the number user entered

            Console.WriteLine("Enter name for patient #" + index.ToString)                           'ask for patient name, start from #1
            array(count) = Console.ReadLine()                                                        'save value to array, start from #0


            Console.WriteLine("Enter the age for patient #" + index.ToString)
            array2(count) = Console.ReadLine()

            count += 1

        Next index



        'JSON
        Dim count2 As Integer = 0

        While True                                                    'Loop

            'Add JSON objects(see PatientClass above) to a list and then serialize the list:
            'refer:  https://stackoverflow.com/questions/27153105/adding-multiple-objects-to-the-same-json-string

            Dim patient As New List(Of PatientClass)            'grab the JSON objects from PatientClass and add them to as List
            Dim p As PatientClass


            For index As Integer = 1 To num                     'for loop until reach the number user entered

                p = New PatientClass()
                p.Name = array(count2)                              '2nd counter for JSON, save value to array, start from #0
                p.BodyTemperature = RandomGenerator()
                p.HeartRate = RandomHeartRateGenerator(array2(count2))

                patient.Add(p)

                count2 += 1

                If (count2 >= count) Then                'reset conter as this is within while loop, if not, the array(count2) will be keep adding nonstop
                    count2 = 0                           'so, we need to reset count2 when it added same to the number of patient
                End If

            Next


            'Note: socket.io emit function do not support JSON type that has STRING for the key {"": ""}:
            'Refer: https://github.com/TSNP218-03/assignment-zy/issues/3

            Dim json = JsonConvert.SerializeObject(patient)     'You will need JsonConvert WHEN you need to desrialize in vb
            Console.WriteLine(json)

            'client.Emit("name", json)                          'To solve the problem mentioned above, do not use emit the JSON type from JsonConvert function.
            client.Emit("data", patient)                        'Instead, Emit the JSON object directly from the PatientClass

        End While

    End Sub

End Module
