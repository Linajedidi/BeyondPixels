using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    bool attackInitiated = false;
    public PickUp pickup;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attackInitiated = true;
            Invoke(nameof(DisableAttack), 1f);
        }
    }

    void DisableAttack()
    {
        attackInitiated = false;
    }


    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.CompareTag("Crystal1") && attackInitiated && pickup.picked)
        {

            Destroy(collision.gameObject,1f);
            Debug.Log("Destroying: " + collision.gameObject.name);
        }
    }

}
