using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectButton : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask buttonMask;
    public float viewRadius;

    [Range(0, 360)]
    public float viewAngle;
    
    public GameObject keyboardPanel;
    public GameObject mousePanel;

    public GameObject buttonOne;
    public GameObject buttonTwo;

    public List<Transform> visibleButtons = new List<Transform>();

    Camera viewCamera;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FindButtonWithDelay", .2f);
    }

    IEnumerator FindButtonWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleButtons();
        }
    }


    void FindVisibleButtons()
    {
        Collider[] buttonsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, buttonMask);

        for (int i = 0; i < buttonsInViewRadius.Length; i++)
        {

            visibleButtons.Clear();

            Transform button_transf = buttonsInViewRadius[i].transform;
            Renderer button_rend = button_transf.GetComponent<Renderer>();


            Vector3 dirToDamages = (button_transf.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToDamages) < viewAngle / 2)
            {
                visibleButtons.Add(button_transf);

                //CHANGE BUTTON COLOR HERE
                Color tempColor = button_rend.material.color;
                tempColor.a = 0.42f;
                button_rend.material.color = tempColor;

                keyboardPanel.GetComponent<KeyBoardManager>().IndicateKeyStart("use");

                if (Input.GetKey(KeyCode.E))
                {
                    GameObject button = button_transf.parent.gameObject;
                    if (button.CompareTag("ButtonOne"))
                    {
                        buttonOne.GetComponent<ChainFalling>().CallThisFromButton(button);
                    }

                    if (button.CompareTag("ChainTwo"))
                    {
                        Debug.Log("I AM IN THE IF CHAIN TWO");
                        buttonTwo.GetComponent<ChainFalling>().CallThisFromButton(button);
                    }

                   
                }
            }
            else
            {
                Color tempColor = button_rend.material.color;
                tempColor.a = 0f;
                button_rend.material.color = tempColor;
                keyboardPanel.GetComponent<KeyBoardManager>().IndicateKeyStop("use");
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
