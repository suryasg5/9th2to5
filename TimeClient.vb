'cerner_2tothe5th_2022
'cerner_2^5_2022
Imports System.Net.Sockets
Imports System.Text
Module Clients
    Sub Main() 
	Try
	    Dim clientSocket As New System.Net.Sockets.Socket(SocketType.Stream, ProtocolType.Tcp)
	    clientSocket.Connect("127.0.0.1", 49152)
		clientSocket.Send(System.Text.Encoding.ASCII.GetBytes("America/New_York" & vbCrLf))
        Dim inStream(2048) As Byte
        Dim msgLen as Integer = clientSocket.Receive(inStream)
        Dim returndata As String = System.Text.Encoding.ASCII.GetString(inStream, 0, msgLen)
        Console.WriteLine("Data from Server : " + returndata)
		clientSocket.Shutdown(SocketShutdown.Both)
	Catch err As Exception
	   Console.WriteLine("Exception caught: {0}", err)
    End Try	
	End Sub
End Module
