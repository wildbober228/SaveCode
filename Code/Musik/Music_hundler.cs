using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_hundler : MonoBehaviour {
    public AudioClip[] idle;
    public AudioClip[] seek;
    public AudioClip[] atack;

    public AudioSource s;
    public void Idle()
    {
        s.PlayOneShot(idle[Random.Range(0,idle.Length)]);
    }

    public void Seek() { }

    public void Atack() { }

    public void Start()
    {
        Idle();
    }
}
