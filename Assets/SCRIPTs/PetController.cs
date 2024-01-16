using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject menu;
    private Vector3 originalPosition;
    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.5f; // Adjust this threshold as needed

    private void Start()
    {
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
