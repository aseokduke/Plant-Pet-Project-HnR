using System.Collections;
using System.IO.Ports;
using UnityEngine;

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
        string portName = "COM8";
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

        // Parse data received from Arduino
        string[] values = data.Split(',');
        if (values.Length == 3)
        {
<<<<<<< HEAD
            temperature = float.Parse(values[0]);
            humidity = float.Parse(values[1]);
            lightLevel = float.Parse(values[2]);
=======
            temperature = float.Parse(values[2].Substring("Temperature:".Length));
            humidity = float.Parse(values[1].Substring("Humidity:".Length));
            lightLevel = float.Parse(values[0].Substring("Light:".Length));
>>>>>>> 09a01f21e5c3f88d5217d4dc3fcdc74682025d15

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

