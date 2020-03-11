using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCart : MonoBehaviour
{
    Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void RunningCart()
    {
        anim.SetTrigger("Activate");

        //anim.SetTrigger("Desactivate");

        //anim.ResetTrigger("Activate");
        //Destroy(button, anim.GetCurrentAnimatorStateInfo(0).length);
    }
}
