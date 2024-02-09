
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Musicsource;
    [SerializeField] AudioSource Soundsource;
 

    public AudioClip Background;
    public AudioClip MonsterrWalk;
    public AudioClip MonsterChase;
    public AudioClip BulletSound;
    public AudioClip Idle;
    public AudioClip MonsterDeath;
    public AudioClip Monsterhit;
    public AudioClip PlayerDeath;
    public AudioClip PlayerRespawn;

    private void start()
    {
        Musicsource.clip = Background;
        Musicsource.Play();

    }
    public void PlaySound(AudioClip sound)
    {
        
            Soundsource.PlayOneShot(sound);


    }
  
}


