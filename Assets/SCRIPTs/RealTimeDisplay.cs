using TMPro;
using UnityEngine;

public class RealTimeDisplay : MonoBehaviour
{
    public TMP_Text temperatureText;
    public TMP_Text humidityText;
    public TMP_Text lightText;

    void Update()
    {
        // Assuming that ArduinoDataReceiver script has static variables for temperature, humidity, and lightLevel
        float temperature = ArduinoDataReceiver.temperature;
        float humidity = ArduinoDataReceiver.humidity;
        float lightLevel = ArduinoDataReceiver.lightLevel;

        // Update UI TextMeshPro with real-time sensor values
        temperatureText.text = "Temperature: " + temperature.ToString("F2") + " C";
        humidityText.text = "Humidity: " + humidity.ToString("F2") + "%";
        lightText.text = "Light: " + lightLevel.ToString("F2");
    }
}



