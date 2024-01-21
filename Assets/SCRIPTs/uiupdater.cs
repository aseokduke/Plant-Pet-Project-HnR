using System.Collections;
using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public TMP_Text temperatureText;
    public TMP_Text humidityText;
    public TMP_Text lightText;

    void Start()
    {
        // Make sure ArduinoDataReceiver is present in the scene
        ArduinoDataReceiver arduinoDataReceiver = FindObjectOfType<ArduinoDataReceiver>();

        if (arduinoDataReceiver == null)
        {
            Debug.LogError("ArduinoDataReceiver not found in the scene.");
            return;
        }

        // Start updating UI
        StartCoroutine(UpdateUI(arduinoDataReceiver));
    }

    IEnumerator UpdateUI(ArduinoDataReceiver arduinoDataReceiver)
    {
        while (true)
        {
            float temperatureValue = ArduinoDataReceiver.temperature;
            float humidityValue = ArduinoDataReceiver.humidity;
            float lightValue = ArduinoDataReceiver.lightLevel;

            // Check if values are valid numbers
            if (!float.IsNaN(temperatureValue) && !float.IsNaN(humidityValue) && !float.IsNaN(lightValue))
            {
                // Update UI TextMeshPro components with real-time sensor values
                temperatureText.text = "Temperature: " + temperatureValue.ToString("F2") + " C";
                humidityText.text = "Humidity: " + humidityValue.ToString("F2") + "%";
                lightText.text = "Light: " + lightValue.ToString("F2");
            }
            else
            {
                Debug.LogError("Received invalid values from ArduinoDataReceiver. Check the data format.");
            }

            yield return new WaitForSeconds(2.5f); // Adjust the update frequency as needed
        }
    }
}
