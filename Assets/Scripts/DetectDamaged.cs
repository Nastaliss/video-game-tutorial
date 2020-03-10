using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDamaged : MonoBehaviour
{
    
    public LayerMask damagesMask;
    public float viewRadius;

    [Range(0, 360)]
    public float viewAngle;

    public GameObject dmg_test;
    public GameObject keyboardPanel;
    public GameObject mousePanel;

    public List<Transform> visibleDmgs = new List<Transform>(); 

    Camera viewCamera;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FindDamagesWithDelay", .2f);
    }

    IEnumerator FindDamagesWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleDamages();
        }
    }


    void FindVisibleDamages()
    {
        Collider[] damagesInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, damagesMask);

        for (int i = 0; i < damagesInViewRadius.Length; i++)
        {
            //Renderer dmg_test_rend = dmg_test.GetComponent<Renderer>();
            //dmg_test_rend.material.color = Color.red;

            visibleDmgs.Clear();  

            Transform damages_transf = damagesInViewRadius[i].transform;
            Renderer damages_rend = damages_transf.GetComponent<Renderer>();

            Vector3 dirToDamages = (damages_transf.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToDamages) < viewAngle/2)
            {
                visibleDmgs.Add(damages_transf); 

                Color tempColor = damages_rend.material.color;
                tempColor.a = 0.42f;
                damages_rend.material.color= tempColor;

                keyboardPanel.GetComponent<KeyBoardManager>().IndicateKey("use");

                if (Input.GetKey(KeyCode.E))
                {

                    //KeyElement.OnKeyPressed();
                    //return;
                }
            }
            else
            {
                Color tempColor = damages_rend.material.color;
                tempColor.a = 0f;
                damages_rend.material.color = tempColor;
            }

        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y; 
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
