Imports System.Net.Sockets
Imports System.Text

Module Module1

    Dim host As String = "127.0.0.1"
    Dim port As Integer = 9000
    Dim client As TcpClient

    Sub Main()

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
    Sub openConnection()
        If client IsNot Nothing Then
            Console.WriteLine("Connection is already open")
        Else
            Try
                client = New TcpClient
                client.Connect(host, port)
                Console.WriteLine("connection been establish")
            Catch ex As Exception

            End Try

        End If
    End Sub
    Sub sendData()
        Dim data As Double
        Dim random As New Random
        Dim temp As Double
        Dim tempSTR As String
        Dim result As Integer = 1
        Dim nwStream As NetworkStream = client.GetStream()
        Dim nwstream2 As NetworkStream = client.GetStream()
        Dim name As String
        Dim name2 As String

        Dim sendAlready As Boolean = False

        Console.WriteLine("Enter first patient name:")
        name = Console.ReadLine()

        Console.WriteLine("Enter second patient name:")
        name2 = Console.ReadLine()

        Dim nametoSend As Byte() = ASCIIEncoding.ASCII.GetBytes(name)
        nwstream2.Write(nametoSend, 0, nametoSend.Length)


        'loop when the result is less than ten
        Do
            'when 10 result send out already send another patient temperature 
            If (result > 10 And sendAlready = False) Then
                nametoSend = ASCIIEncoding.ASCII.GetBytes(name2)
                nwstream2.Write(nametoSend, 0, nametoSend.Length)
                sendAlready = True
            End If

            'generate random temp within range
            temp = random.NextDouble() * (40.0 - 37.0) + 37.0
            temp = Math.Round(temp, 2)
            tempSTR = CStr(temp)
            Console.WriteLine("temperature is:" + tempSTR)


            'set the temp to data 
            data = temp

            'send data
            Dim bytetoSend As Byte() = ASCIIEncoding.ASCII.GetBytes(data)
            nwStream.Write(bytetoSend, 0, bytetoSend.Length)

            'wait for one second 
            Threading.Thread.Sleep(1000)

            result += 1
        Loop While (result <> 21)





    End Sub

    Sub closeConnection()
        If client IsNot Nothing Then
            client.Close()
            Console.WriteLine("connection been close")
        Else
            Console.WriteLine("client already close ")

        End If
    End Sub

End Module
