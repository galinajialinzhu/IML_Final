using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class USBSerialCommunication : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600); // Adjust the COM port and baud rate as needed

    void Start()
    {
        try
        {
            serialPort.Open();
            serialPort.ReadTimeout = 10;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error opening serial port: " + e.Message);
        }
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();
                // Process the received data (e.g., handle button presses)
                Debug.Log("Received data: " + data);
            }
            catch (System.Exception e)
            {
                // Handle exceptions (e.g., timeout or disconnect)
                Debug.LogError("Error reading serial data: " + e.Message);
            }
        }
    }

    void OnDestroy()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
