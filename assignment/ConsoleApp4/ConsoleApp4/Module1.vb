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

        Console.Clear()

        Dim lineRead As String = 0

        Do

            Console.WriteLine("1.-open 2.-send 3.-close 4.-quit ")
            lineRead = Console.ReadLine
            Select Case lineRead
                'establish connecttion
                Case "1"
                    openConnection()

                'send data
                Case "2"
                    sendData()

                'close connection 
                Case "3"
                    closeConnection()

            End Select


        Loop While lineRead <> 4


    End Sub

    Public Class PatientClass                                              'JSON Classs


        Public Name As String
        Public BodyTemperature As String
        'will add more JSON Class later

    End Class



    Sub openConnection()
        'If client IsNot Nothing Then
        '    Console.WriteLine("Connection is already open")
        'Else
        '    Try
        '        client = New TcpClient
        '        client.Connect(host, port)
        '        Console.WriteLine("connection been establish")
        '    Catch ex As Exception

        '    End Try

        'End If
    End Sub
    Sub sendData()

        Dim random As New Random

        Dim temp As Double
        Dim tempSTR As String
        'Dim result As Integer = 1

        Dim name As String
        Dim name2 As String

        'Dim sendAlready As Boolean = False

        Console.WriteLine("Enter first patient name:")
        name = Console.ReadLine()

        Console.WriteLine("Enter second patient name:")
        name2 = Console.ReadLine()


        'commenting out sendAlready function 
        'loop when the result is less than ten
        'Do
        '    'when 10 result send out already send another patient temperature 
        '    If (result > 10 And sendAlready = False) Then
        '        'nametoSend = ASCIIEncoding.ASCII.GetBytes(name2)
        '        ' nwstream2.Write(nametoSend, 0, nametoSend.Length)
        '        sendAlready = True
        '    End If


        'As we are trying to send real time data, sendAlready function above is not using anymore.

        While True

            'generate random temp within range
            temp = random.NextDouble() * (40.0 - 37.0) + 37.0
            temp = Math.Round(temp, 2)
            tempSTR = CStr(temp)
            Console.WriteLine("temperature is:" + tempSTR)
            'wait for one second 
            Threading.Thread.Sleep(1000)

            'result += 1  (This is part of sendAlready function, will remove in next pull request)

            'Trying to use add multiple value to the same one JSON class 
            'Refer https://stackoverflow.com/questions/27153105/adding-multiple-objects-to-the-same-json-string


            Dim patient As New List(Of PatientClass)            'grab the JSON objects from PatientClass and add them to as List
            Dim p As PatientClass

            '1st patient data
            p = New PatientClass()                               'JSON Serialize the List
            p.Name = name
            p.BodyTemperature = tempSTR
            patient.Add(p)

            '2nd patient data
            p = New PatientClass()
            p.Name = name2
            p.BodyTemperature = tempSTR
            patient.Add(p)

            'Note: socket.io emit function do not support JSON type that has STRING for the key {"": ""}:
            'Refer: https://github.com/TSNP218-03/assignment-zy/issues/3

            Dim json = JsonConvert.SerializeObject(patient)     'You will need JsonConvert WHEN you need to desrialize in vb
            Console.WriteLine(json)

            'client.Emit("data", json)                          'To solve the problem mentioned above, do not use emit the JSON type from JsonConvert function.
            client.Emit("data", patient)                        'Instead, Emit the JSON object directly from the PatientClass



        End While


        ' Loop While (result <> 21) (This is part of sendAlready function, will remove in next pull request)





    End Sub

    Sub closeConnection()
        'If client IsNot Nothing Then
        '    client.Close()
        '    Console.WriteLine("connection been close")
        'Else
        '    Console.WriteLine("client already close ")

        'End If
    End Sub

End Module
