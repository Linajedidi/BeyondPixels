using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolPickUp : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject PlayerPistol;
    public GameObject pistol;
    private bool isInRange = false;
    [HideInInspector] public bool picked = false;
    private Animator anim;
    private GameObject child;
    public int Ammo = 0;


    private void Start()
    {
        PlayerPistol.SetActive(false);
        uiObject.SetActive(false);
        child = transform.GetChild(0).gameObject;


    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            PlayerPistol.SetActive(true);
            picked = true;
            Debug.Log("the object is picked ");
            child.SetActive(false);
            uiObject.SetActive(false);
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
