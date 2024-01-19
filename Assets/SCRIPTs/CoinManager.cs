using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static int coins = 0;
    public Text coinText; // Reference to the Text element in the UI

    void Start()
    {
        coins = 0; // Initialize coins to zero
        UpdateCoinUI();

        InvokeRepeating("IncreaseCoins", 0f, 3600f); // Invoke every hour
    }

    void IncreaseCoins()
    {
        coins += 10;
        UpdateCoinUI();
    }

    void UpdateCoinUI()
    {
        // Update the UI to display the new coin count
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
        else
        {
            Debug.LogError("Coin Text reference is null in the CoinManager script. Assign the UI Text element.");
        }
    }
}
