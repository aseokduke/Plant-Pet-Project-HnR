using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    // The name of the scene you want to load
    public string ActualGame;

    // This function is called when the button is clicked
    public void OnButtonClick()
    {
        // Load the specified scene
        SceneManager.LoadScene(ActualGame);
    }
}
