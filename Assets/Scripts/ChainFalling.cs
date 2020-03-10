using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainFalling : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void CallThisFromButton(GameObject chain)
    {
        anim.SetTrigger("Activate");
        Destroy(chain, anim.GetCurrentAnimatorStateInfo(0).length);
    }
}
