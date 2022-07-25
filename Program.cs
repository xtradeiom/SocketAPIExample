using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;

 // Connect to a remote device.  
try { 
    byte[] bytes = new byte[1024];  
    
    // Establish the remote endpoint for the socket.  
    IPHostEntry ipHostInfo = Dns.GetHostEntry("socket-api.racelab.global");  
    IPAddress ipAddress = ipHostInfo.AddressList[0];  
    IPEndPoint remoteEP = new IPEndPoint(ipAddress,5000);  

    // Create a TCP/IP  socket.  
    Socket sender = new Socket(ipAddress.AddressFamily,
        SocketType.Stream, ProtocolType.Tcp );  

    // Connect the socket to the remote endpoint. Catch any errors.  
    try {  
        sender.Connect(remoteEP);  

        Console.WriteLine("Socket connected to {0}");

        while (true) {
            // Receive the response from the remote device.  
            int bytesRec = sender.Receive(bytes);

            Console.WriteLine(Encoding.ASCII.GetString(bytes,0,bytesRec));
        }        

        // Release the socket.  
        sender.Shutdown(SocketShutdown.Both);  
        sender.Close();

    } catch (ArgumentNullException ane) {  
        Console.WriteLine("ArgumentNullException : {0}",ane.ToString());  
    } catch (SocketException se) {  
        Console.WriteLine("SocketException : {0}",se.ToString());  
    } catch (Exception e) {  
        Console.WriteLine("Unexpected exception : {0}", e.ToString());  
    }  

} catch (Exception e) {  
    Console.WriteLine( e.ToString());  
}  