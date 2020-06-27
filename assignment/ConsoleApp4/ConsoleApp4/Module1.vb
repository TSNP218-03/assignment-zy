
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
        Public BloodPressure As String

    End Class

    Function RandomGenerator() As String

        Dim temp As Double
        Dim tempSTR As String

        Dim random As New Random

        temp = random.NextDouble() * (40.0 - 37.0) + 37.0                         'patient body temperature generator from 37 to 40 (celsius)
        temp = Math.Round(temp, 1)
        tempSTR = CStr(temp)
        'Console.WriteLine("body temperature is:" + tempSTR)
        Threading.Thread.Sleep(500)                                               '1 second cycle
        RandomGenerator = tempSTR                                                  'Return as tempSTR 

    End Function


    Sub sensorNode()  'previosuly known as sendData()

        Dim num As Integer
        Console.WriteLine("Enter the number of patient u would to monitor:")                           'ask for patient name
        num = Console.ReadLine()

        Dim array(100) As String                                                                      'declare array
        Dim count As Integer = 0                                                                      'counter for array         

        For index As Integer = 1 To num                                                               'for loop until reach the number user entered

            Console.WriteLine("Enter name for patient #" + index.ToString)                           'ask for patient name, start from #1
            array(count) = Console.ReadLine()                                                        'save value to array, start from #0
            count += 1

        Next index



        ''Keeeping until next pull request```

        'Dim name As String                                                        'init
        '    Dim name2 As String
        'Dim name3 As String

        'Console.WriteLine("Enter first patient name:")                           'ask for patient name
        'name = Console.ReadLine()

        'Console.WriteLine("Enter 2nd patient name:")
        'name2 = Console.ReadLine()

        'Console.WriteLine("Enter 3rd patient name:")
        'name3 = Console.ReadLine()

        Dim count2 As Integer = 0

        While True

            'Add JSON objects(see PatientClass above) to a list and then serialize the list:
            'refer:  https://stackoverflow.com/questions/27153105/adding-multiple-objects-to-the-same-json-string

            Dim patient As New List(Of PatientClass)            'grab the JSON objects from PatientClass and add them to as List
            Dim p As PatientClass


            For index As Integer = 1 To num                     'for loop until reach the number user entered

                p = New PatientClass()
                p.Name = array(count2)                              '2nd counter for JSON, save value to array, start from #0
                p.BodyTemperature = RandomGenerator()
                p.HeartRate = RandomGenerator()
                p.BloodPressure = RandomGenerator()
                patient.Add(p)

                count2 += 1

                If (count2 >= count) Then                'reset conter as this is within while loop, if not, the array(count2) will be keep adding nonstop
                    count2 = 0                           'so, we need to reset count2 when it added same to the number of patient
                End If

            Next



            ''Keeeping until next pull request```

            ''1st patient data
            'p = New PatientClass()                               'JSON Serialize the List
            'p.Name = array(0)
            'p.BodyTemperature = RandomGenerator()
            'p.HeartRate = RandomGenerator()
            'p.BloodPressure = RandomGenerator()
            'patient.Add(p)

            ''2nd patient data
            'p = New PatientClass()
            'p.Name = array(1)
            'p.BodyTemperature = RandomGenerator()
            'p.HeartRate = RandomGenerator()
            'p.BloodPressure = RandomGenerator()
            'patient.Add(p)

            ''3rd patient data
            'p = New PatientClass()
            'p.Name = array(2)
            'p.BodyTemperature = RandomGenerator()
            'p.HeartRate = RandomGenerator()
            'p.BloodPressure = RandomGenerator()
            'patient.Add(p)


            'Note: socket.io emit function do not support JSON type that has STRING for the key {"": ""}:
            'Refer: https://github.com/TSNP218-03/assignment-zy/issues/3

            Dim json = JsonConvert.SerializeObject(patient)     'You will need JsonConvert WHEN you need to desrialize in vb
            Console.WriteLine(json)

            'client.Emit("name", json)                          'To solve the problem mentioned above, do not use emit the JSON type from JsonConvert function.
            client.Emit("data", patient)                        'Instead, Emit the JSON object directly from the PatientClass

        End While

    End Sub

End Module
