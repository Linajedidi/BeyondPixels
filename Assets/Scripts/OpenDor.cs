using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDor : MonoBehaviour
{
    public AnyObjectPickUp anyObjectPickUp;
    public Animator anim; 
    private void OnTriggerEnter(Collider other)
    {
        if (anyObjectPickUp != null && anyObjectPickUp.picked && other != null && other.gameObject.CompareTag("Player"))
        {
            
            StartCoroutine(OpenDoorAfterTime());

        }
    }
    IEnumerator OpenDoorAfterTime()
    {
        GameObject doorObject = GameObject.FindGameObjectWithTag("Door");
        GameObject KeObject = GameObject.FindGameObjectWithTag("Key");
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("Open");
        Destroy(KeObject);
        Debug.Log("Key Destroyed");
    }


}
