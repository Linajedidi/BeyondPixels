
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterClickHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public string readLetterSceneName = "ReadLetterScene";

    private void OnMouseDown()
    {
        // Load the scene where the AI reads the letter
        SceneManager.LoadScene(readLetterSceneName);
    }
}
