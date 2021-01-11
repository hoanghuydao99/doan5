using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip item, swords, fireball, jump;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        item = Resources.Load<AudioClip>("Item");
        swords = Resources.Load<AudioClip>("Sword");
        fireball = Resources.Load<AudioClip>("FireBall");
        jump = Resources.Load<AudioClip>("nhay");

        audio = GetComponent<AudioSource>();
    }

    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "1":
                audio.clip = item;
                audio.PlayOneShot(item, 1f);
                break;


            case "2":
                audio.clip = swords;
                audio.PlayOneShot(swords, 1f);
                break;

            case "3":
                audio.clip = fireball;
                audio.PlayOneShot(fireball, 1f);
                break;

            case "4":
                audio.clip = jump;
                audio.PlayOneShot(jump, 1f);
                break;
        }
    }
}
