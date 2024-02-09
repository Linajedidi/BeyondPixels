using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PickUp : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject PlayerStick;
    public GameObject stick;
    private bool isInRange = false;
    [HideInInspector]public bool picked = false;
    private Animator anim;
    private GameObject child;
   

    private void Start()
    {
        PlayerStick.SetActive(false);
        uiObject.SetActive(false);
        child = transform.GetChild(0).gameObject;
 

    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            PlayerStick.SetActive(true);
            picked = true;
            child.SetActive(false);
            uiObject.SetActive(false);
        }
        if (picked && Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("hit");
        }
        if (picked)
        {
            uiObject.SetActive(false);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim = other.transform.GetChild(0).GetComponent<Animator>();
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