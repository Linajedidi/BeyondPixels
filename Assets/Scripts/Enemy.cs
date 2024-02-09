using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AudioManager audiomanager;
    public int Hp = 100;
    public Animator anim;
    public Animator Playeranim;
    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
    }
 
    public void TakeDamage(int damageAmount)
    {
        GameObject Pistol = GameObject.FindGameObjectWithTag("pistol");
        Hp -= damageAmount;
        if(Hp <= 0)
        {
            anim.SetTrigger("Die");
            
            GetComponent<Collider>().enabled = false;
            audiomanager.PlaySound(audiomanager.MonsterDeath);
            Destroy(Pistol);
            Playeranim.SetBool("IsShooting", false);
            Playeranim.SetBool("isAiming",false);

        }
        else
        {
            anim.SetTrigger("GetHit");
            audiomanager.PlaySound(audiomanager.Monsterhit);
        }
    }
}
