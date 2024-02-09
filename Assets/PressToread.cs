using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToread : MonoBehaviour
{
    public GameObject uiObject;
   

    public GameObject Object;
    private bool isInRange = false;
    

    public GameObject GO;
    //private GameObject child;


    private void Start()
    {
       
        uiObject.SetActive(false);
        //child = transform.GetChild(0).gameObject;


    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            EnablePrefabAndChildren(GO);


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
    private void EnablePrefabAndChildren(GameObject go)
    {
       
        go.SetActive(true);
   
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
