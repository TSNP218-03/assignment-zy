Imports System
Imports System.Threading.Tasks
Imports H.Socket.IO

Public Module Module1


	Public Sub Main()

		' declare var
		Dim client As SocketIoClient = New SocketIoClient()
		Dim serverSeed As Integer
		Dim rand As Integer
		rand = CInt(Int((99 * Rnd()) + 1))

		' nodejs URL
		client.ConnectAsync(New Uri("http://127.0.0.1:55555"))
			Console.WriteLine("Connecting...")

			' getting numbers from the seed server
			client.On("res-seed", Sub(message)
									  Console.WriteLine("Server seed number: " + message.ToString())
									  serverSeed = message

									  ' guess number 
									  While serverSeed <> rand
										  rand = CInt(Int((99 * Rnd()) + 1))
										  Console.WriteLine("My guess:" + rand.ToString())

										  'stop the guess if number is found
										  If serverSeed = rand Then
											  Console.WriteLine("I guessed the server number:" + rand.ToString())
											  Console.WriteLine("Press any key to exit")
										  End If

									  End While

								  End Sub)

		' wait for user input, to prevent program exit
		Console.ReadKey(True)
    End Sub
End Module
