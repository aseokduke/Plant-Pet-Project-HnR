using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject menu;
    private Vector3 originalPosition;
    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.5f; // Adjust this threshold as needed

    // Healthbar Variables
    // [SerializeField] float health, maxHealth = 3f;
    [SerializeField] PetHealthbar tempBar;
    [SerializeField] float temp, maxTemp;
    [SerializeField] TextMeshProUGUI tempStr;

    [SerializeField] PetHealthbar moistureBar;
    [SerializeField] float moisture, maxMoisture;
    [SerializeField] TextMeshProUGUI moistureStr;

    [SerializeField] PetHealthbar lightBar;
    [SerializeField] float lightIntensity, maxLightIntensity;
    [SerializeField] TextMeshProUGUI lightStr;

    private void Start()
    {
        temp = 100;
        maxTemp = 100;
        tempStr.text = temp.ToString() + "°C";
        tempBar.UpdateHealthBar(temp, maxTemp);

        moisture = 90;
        maxMoisture = 100;
        moistureStr.text = moisture.ToString() + "%";
        moistureBar.UpdateHealthBar(moisture, maxMoisture);

        lightIntensity = 80;
        maxLightIntensity = 100;
        lightStr.text = lightIntensity.ToString() + "%";
        lightBar.UpdateHealthBar(lightIntensity, maxLightIntensity);

        originalPosition = transform.position;
        StartCoroutine(RandomMovement());
    }

    private IEnumerator RandomMovement()
    {
        while (true)
        {
            // Randomly stop or move
            bool shouldMove = Random.Range(0f, 1f) > 0.5f;

            if (shouldMove)
            {
                Vector3 randomPosition = new Vector3(Random.Range(0f, 1f), 0f, 0f);
                Vector3 targetPosition = Camera.main.ViewportToWorldPoint(randomPosition);
                targetPosition.y = transform.position.y;

                while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                    yield return null;
                }
            }

            // Randomly stop for a duration
            float stopDuration = Random.Range(1f, 5f);
            yield return new WaitForSeconds(stopDuration);

            // Return to the original position
            float returnDuration = 2f; // Adjust this duration as needed
            float elapsedReturnTime = 0f;

            while (elapsedReturnTime < returnDuration)
            {
                transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
                elapsedReturnTime += Time.deltaTime;
                yield return null;
            }

            yield return null; // Optional, add a small delay between movements
        }
    }

    private void OnMouseDown()
    {
        if (menu != null)
        {
            menu.SetActive(!menu.activeSelf);

            // Check for double click
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickThreshold)
            {
                // Load the new scene for a double click
                SceneManager.LoadScene("menu");
            }

            lastClickTime = Time.time;
        }
    }
}
