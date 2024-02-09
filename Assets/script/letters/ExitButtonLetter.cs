using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonLetter : MonoBehaviour
{


    private void Start()
    {
        
        DisablePrefabAndChildren(gameObject);
    }
 
    public void DisablePrefabAndChildren(GameObject go)
    {
        // Disable the current GameObject
        go.SetActive(false);

        // Disable all child GameObjects recursively
        foreach (Transform child in go.transform)
        {
            DisablePrefabAndChildren(child.gameObject);
        }
    }
}

