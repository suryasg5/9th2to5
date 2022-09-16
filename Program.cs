//cerner_2tothe5th_2022
//cerner_2^5_2022
namespace Client {
class Program {
static void Main(string[] args) {
	try {
		System.Net.IPAddress ipAddr = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0];
		System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(ipAddr.AddressFamily,System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
		socket.Connect(new System.Net.IPEndPoint(ipAddr, 49152));
		socket.Send(System.Text.Encoding.ASCII.GetBytes("America/New_York\n"));
		byte[] messageReceived = new byte[1024];
		int byteRecv = socket.Receive(messageReceived);
		System.Console.WriteLine(System.Text.Encoding.ASCII.GetString(messageReceived,0, byteRecv));
		socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
		socket.Close();
	}
	catch (System.Exception e) {
		System.Console.WriteLine(e.ToString());
	}
}
}
}
