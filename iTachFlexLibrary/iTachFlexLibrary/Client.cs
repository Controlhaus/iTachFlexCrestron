using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronSockets;

namespace iTachFlexLibrary
{
    public class TCPClientClass
    {
        public uint debug = 0;
        TCPClient tcpClient;

        public delegate void ReceiveDataHandler(SimplSharpString data);
        public ReceiveDataHandler OnDataReceiveEvent { set; get; }

        public void InitializeTcpClient(string addressToConnectTo, uint portNumber, uint bufferSize)
        { 
            tcpClient = new TCPClient(addressToConnectTo, (int)portNumber, (int)bufferSize);
            if (debug > 0)
            {
                CrestronConsole.PrintLine("\n TCPClientClass InitializeTcpClient addressToConnectTo: {0}, portNumber: {1}, bufferSize: {2}", addressToConnectTo, portNumber, bufferSize);
            }
        }

        public void ConnectToServer()
        {
            SocketErrorCodes returnCode = tcpClient.ConnectToServer();
            if (debug > 0)
            {
                CrestronConsole.PrintLine("\n TCPClientClass ConnectToServer returnCode: " + returnCode.ToString());
            }

            if (returnCode == 0)
            {
                tcpClient.ReceiveDataAsync(OnDataReceiveEventCallback);
            }
        }

        public void DisconnectFromServer()
        {
            SocketErrorCodes returnCodes = tcpClient.DisconnectFromServer();
            if (debug > 0)
            {
                CrestronConsole.PrintLine("TCPClientClass DisconnectFromServer returnCodes: " + returnCodes);
            }
        }

        public void OnDataReceiveEventCallback(TCPClient myTCPClient, int numberOfBytesReceived)
        {
            if (numberOfBytesReceived > 0)
            { 
                SimplSharpString data = new SimplSharpString();
                data = System.Text.Encoding.Default.GetString(tcpClient.IncomingDataBuffer, 0, numberOfBytesReceived);
                OnDataReceiveEvent(data);
            }
            tcpClient.ReceiveDataAsync(OnDataReceiveEventCallback);
        }

        public void SendData(SimplSharpString dataToSend)
        { 
            byte[] pBufferToSend = System.Text.Encoding.ASCII.GetBytes(dataToSend.ToString());
            SocketErrorCodes returnCode = tcpClient.SendData(pBufferToSend, pBufferToSend.Length);
            if (debug > 0)
            {
                CrestronConsole.PrintLine("\n TCPClientClass SendData returnCode: " + returnCode.ToString());
            }
        }
    }
}