using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDamaged : MonoBehaviour
{
    
    public LayerMask damagesMask;

    Camera viewCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y))
    }

    void FindVisibleDamages()
    {
        Collider[] damagesInViewRadius = Physics.OverlapSphere(transform.position, 360, damagesMask);

        for (int i = 0; i < damagesInViewRadius.Length; i++)
        {
            Transform damages = damagesInViewRadius[i].transform;
            Vector3 dirToDamages = (damages.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToDamages) < 45)
            {
                GameObject Chain = damages.transform.parent.gameObject;
                Chain.GetComponent<Renderer>.material.color = Color.red;
            }
        }
    }
}
