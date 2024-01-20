using TMPro;
using UnityEngine;

public class RealTimeDisplay : MonoBehaviour
{
    public TMP_Text temperatureText;
    public TMP_Text humidityText;
    public TMP_Text lightText;

    void Update()
    {
        // Update UI TextMeshPro with real-time sensor values
        temperatureText.text = "Temperature: " + ArduinoDataReceiver.temperature.ToString("F2") + " C";
        humidityText.text = "Humidity: " + ArduinoDataReceiver.humidity.ToString("F2") + "%";
        lightText.text = "Light: " + ArduinoDataReceiver.lightLevel.ToString("F2");
    }
}
