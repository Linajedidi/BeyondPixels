using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public Button exitButton; // Reference to the UI button for exiting

    void Start()
    {
        // Add a listener to the exit button
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    // Method to be called when the exit button is clicked
    private void OnExitButtonClick()
    {
        // Load the "Show" scene
        SceneManager.LoadScene("Show");
    }
}
