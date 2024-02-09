using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyObjectPickUp : MonoBehaviour
{
   
    public GameObject uiObject;
    public GameObject PlayerObject;
    public GameObject Object;
    private bool isInRange = false;
    [HideInInspector] public bool picked = false;
    
    private GameObject child;


    private void Start()
    {
        PlayerObject.SetActive(false);
        uiObject.SetActive(false);
        child = transform.GetChild(0).gameObject;


    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            PlayerObject.SetActive(true);
            picked = true;
            child.SetActive(false);
            uiObject.SetActive(false);
        }
       


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            uiObject.SetActive(true);
            isInRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiObject.SetActive(false);
            isInRange = false;
        }
    }
}
