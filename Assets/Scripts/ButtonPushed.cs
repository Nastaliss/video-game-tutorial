using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushed : MonoBehaviour
{
    Animator anim;

    public GameObject playersCart;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void CallThisFromButton()
    {
        anim.SetTrigger("Activate");
        

        playersCart.GetComponent<RunCart>().RunningCart();
        

        //anim.SetTrigger("Desactivate");
        //Destroy(button, anim.GetCurrentAnimatorStateInfo(0).length);
    }
}
