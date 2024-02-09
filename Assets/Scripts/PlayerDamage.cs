using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    AudioManager audiomanager;
    public HealthBar healthBar;
    [SerializeField] int Hp = 100;
    public Animator anim;
    public Transform respawnPoint;
    int maxHp = 100;


    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void Start()
    {
        HealthBar healthBar = GetComponent<HealthBar>();
    }

    public int GetHp()
    {
        return Hp;
    }

    public void TakeDamage(int damageAmount)
    {
        if (Hp > 0)
        {
            if (Hp - damageAmount < 0)
            {
                damageAmount = Hp;
            }
            Hp -= damageAmount;
            healthBar.UpdateHealthBar(Hp, maxHp);
        }

        if (Hp <= 0)
        {
            anim.SetTrigger("Die");


            audiomanager.PlaySound(audiomanager.PlayerDeath);
            StartCoroutine(DestroyPlayer());
        }

    }
    private IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(0f);
        Hp = 100;
        healthBar.UpdateHealthBar(Hp, maxHp);
        audiomanager.PlaySound(audiomanager.PlayerRespawn);

        transform.position = respawnPoint.position;



    }

}
