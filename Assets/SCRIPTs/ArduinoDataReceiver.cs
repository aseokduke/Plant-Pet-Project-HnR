using System.Collections;
using UnityEngine;
using System.IO.Ports;

public class ArduinoDataReceiver : MonoBehaviour
{
    public static float temperature;
    public static float humidity;
    public static float lightLevel;

    private static ArduinoDataReceiver instance;
    private SerialPort serialPort;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Adjust the port name and baud rate based on your Arduino setup
        string portName = "COM3";
        int baudRate = 9600;

        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();

        StartCoroutine(ReadData());
    }

    IEnumerator ReadData()
    {
        while (true)
        {
            try
            {
                string data = serialPort.ReadLine();
                ProcessData(data);
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Error reading serial data: " + e.Message);
            }

            yield return new WaitForSeconds(2.5f);
        }
    }

    void ProcessData(string data)
    {
        Debug.Log($"Received data: {data}");

        // Convert the received data to lowercase to make it case-insensitive
        data = data.ToLower();

        // Parse data received from Arduino
        string[] values = data.Split(',');
        Debug.Log($"Number of values: {values.Length}");

        if (values.Length == 3)
        {
            temperature = float.Parse(values[2].Substring("temperature:".Length).Trim());
            humidity = float.Parse(values[1].Substring("humidity:".Length).Trim());
            lightLevel = float.Parse(values[0].Substring("light:".Length).Trim());

            Debug.Log($"Parsed data - Temperature: {temperature}, Humidity: {humidity}, Light: {lightLevel}");
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}

