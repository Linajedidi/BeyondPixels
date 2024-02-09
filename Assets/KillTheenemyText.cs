using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillTheenemyText : MonoBehaviour
{
    public GameObject text; 
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            text.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }
}
