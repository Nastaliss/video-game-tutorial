using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushed : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void CallThisFromButton(GameObject button)
    {
        anim.SetTrigger("Activate");
        Destroy(button, anim.GetCurrentAnimatorStateInfo(0).length);
    }
}
