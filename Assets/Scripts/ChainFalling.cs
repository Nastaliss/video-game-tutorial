using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainFalling : MonoBehaviour
{
    Animator anim;
    AudioSource my_AudioSource;

    void Start()
    {
        my_AudioSource = GetComponent<AudioSource>();
        my_AudioSource.Stop();
        anim = GetComponent<Animator>();
    }

    public void CallThisFromButton(GameObject chain)
    {
        anim.SetTrigger("Activate");
        my_AudioSource.Play();
        Destroy(chain, anim.GetCurrentAnimatorStateInfo(0).length);
    }
}
