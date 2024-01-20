using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PetRequirements : MonoBehaviour
{
    public TextMeshProUGUI output;
    public TMP_InputField input;

    public float idealTemp;
    public float idealMoisture;
    public float idealLight;

    public void TempSubmit()
    {
        output.text = "Ideal Temperature: " + input.text + "°C";
    }

    public void MoistureSubmit()
    {
        output.text = "Ideal Moisture: " + input.text + "%";
    }

    public void LightSubmit()
    {
        output.text = "Ideal Light: " + input.text + "%";
    }
}