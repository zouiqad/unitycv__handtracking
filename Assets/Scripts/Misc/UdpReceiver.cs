using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UdpReceiver : MonoBehaviour
{
    [SerializeField] private int PORT = 5000; // Set your desired port

    private UdpClient udpClient;
    private string message;

    void Start()
    {
        udpClient = new UdpClient(PORT);
        BeginReceiving();
    }

    private void BeginReceiving()
    {
        udpClient.BeginReceive(ReceiveCallback, null);
    }

    private void ReceiveCallback(IAsyncResult ar)
    {
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, PORT);
        byte[] data = udpClient.EndReceive(ar, ref remoteEP);
        message = Encoding.ASCII.GetString(data);

        //Debug.Log("Received data: " + message);

        // Continue receiving data
        BeginReceiving();
    }

    public string GetData()
    {
        return message;
    }

    void OnDestroy()
    {
        if (udpClient != null)
        {
            udpClient.Close();
        }
    }
}
