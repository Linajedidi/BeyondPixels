using UnityEngine;

public class ReplayButton : MonoBehaviour
{
    public Dialogue dialogue;

    public void OnReplayButtonClick()
    {
        if (dialogue != null)
        {
            dialogue.ReplayDialogue();
        }
    }
}
