using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;

 // Connect to a remote device.  
try { 
    byte[] bytes = new byte[1024];  
    
    // Establish the remote endpoint for the socket.
    // TODO: Set the remote hostname here
    IPHostEntry ipHostInfo = Dns.GetHostEntry("hostname here");
    IPAddress ipAddress = ipHostInfo.AddressList[0];  
    // TODO: Set the correct port here
    IPEndPoint remoteEP = new IPEndPoint(ipAddress,9999);

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

            // TODO: Implement logic

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