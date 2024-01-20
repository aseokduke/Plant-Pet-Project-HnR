using TMPro;
using UnityEngine;

public class RealTimeDisplay : MonoBehaviour
{
	public TMP_Text temperatureText;
	public TMP_Text humidityText;
	public TMP_Text lightText;

	void Update()
	{
		Debug.Log("Update method called");

		// Check if any of the TextMeshPro components is null before updating
		if (temperatureText != null && humidityText != null && lightText != null)
		{
			// Update UI TextMeshPro with real-time sensor values
			temperatureText.text = "Temperature: " + ArduinoDataReceiver.temperature.ToString("F2") + " C";
			humidityText.text = "Humidity: " + ArduinoDataReceiver.humidity.ToString("F2") + "%";
			lightText.text = "Light: " + ArduinoDataReceiver.lightLevel.ToString("F2");
		}
		else
		{
			Debug.LogError("One or more TextMeshPro components is null. Please check the assignments in the Inspector.");
		}
	}
}


