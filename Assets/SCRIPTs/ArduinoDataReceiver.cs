using System.Collections;
using System.IO;
using UnityEngine;

public class ArduinoDataReceiver : MonoBehaviour
{
    public static float temperature;
    public static float humidity;
    public static float lightLevel;

    private static ArduinoDataReceiver instance;
    private string filePath;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        filePath = Path.Combine(Application.persistentDataPath, "ArduinoData.txt");
        StartCoroutine(ReadData());
    }

    IEnumerator ReadData()
    {
        while (true)
        {
            try
            {
                // Check if the file exists, and create it if not
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "");
                }

                string data = File.ReadAllText(filePath);
                ProcessData(data);
            }
            catch (IOException e)
            {
                Debug.LogWarning("Error reading file: " + e.Message);
            }

            yield return new WaitForSeconds(2.5f);
        }
    }

    void ProcessData(string data)
    {
        // Parse data received from Arduino
        string[] values = data.Split(',');
        if (values.Length == 3)
        {
            temperature = float.Parse(values[2].Substring("Temperature:".Length));
            humidity = float.Parse(values[1].Substring("Humidity:".Length));
            lightLevel = float.Parse(values[0].Substring("Light:".Length));
        }
    }
}
