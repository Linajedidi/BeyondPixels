using System.Collections;

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public string[] lines;
    public float textSpeed;
    private int index;
   [SerializeField] private AudioClip letter;
    private ExitButtonLetter exitButton;
    // Start is called before the first frame update
    private void OnEnable()
    {
        textMesh.text = string.Empty;
        StartDialogue();
        SoundManger.Instance.PlaySound(letter);
        exitButton = FindObjectOfType<ExitButtonLetter>();
    }
    private void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            if(textMesh.text == lines[index]) { 
                NextLine();
                //SoundManger.Instance.PlaySound(letter);
            }
            else
            {
                StopAllCoroutines();
                textMesh.text = lines[index];
            }
        }
       
    }
     void StartDialogue()
    {
         index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textMesh.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if(index < lines.Length-1)
        {
            index++;
            textMesh.text =string.Empty;
            StartCoroutine(TypeLine());

        }
        else
        {
            //StartCoroutine(DelayAndLoadScene());
        }
       
    }
   /* IEnumerator DelayAndLoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Show");
    }*/
    public void ReplayDialogue()
    {
        StopAllCoroutines();
        textMesh.text = string.Empty;
        StartDialogue();
        SoundManger.Instance.PlaySound(letter);
    }
}
