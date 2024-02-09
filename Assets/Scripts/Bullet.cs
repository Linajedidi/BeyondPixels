using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    
    public int damageAmount = 40;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy"  )
        {

            other.GetComponent<Enemy>().TakeDamage(damageAmount);
            
        }
    }

}
