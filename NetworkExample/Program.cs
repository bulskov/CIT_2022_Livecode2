// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;


var server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
server.Start();

Console.WriteLine("Server is started...");

while(true)
{
    var client = server.AcceptTcpClient();
    Console.WriteLine("Client accepted...");
    var stream = client.GetStream();

    var buffer = new byte[1024];

    var rcnt = stream.Read(buffer, 0, buffer.Length);

    var request = Encoding.UTF8.GetString(buffer, 0, rcnt);

    Console.WriteLine(request);

    var response = "HTTP/1.1 200 Ok\nContent-Type: text/plain\n\nHello from server :-)";

    var responseBuffer = Encoding.UTF8.GetBytes(response);

    stream.Write(responseBuffer);

    stream.Close(); 
}

