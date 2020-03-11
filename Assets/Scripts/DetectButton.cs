using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectButton : MonoBehaviour
{
    Camera viewCamera;

    public float viewRadius;

    [Range(0, 360)]
    public float viewAngle;

    public GameObject keyboardPanel;
    public MouseManager mousePanel;


    public List<GameObject> buttons;
    public List<Transform> visibleButtons = new List<Transform>();

    private float VISIBILITY_THRESHOLD = .8f;


    // Start is called before the first frame update
    void Start()
    {
    }


    void Update()
    {
        // TODO: Break down in smaller functions
        GameObject ButtonSelected = null;

        foreach (GameObject Button in buttons)
        {
            if (GetTargetGameObjectVisibility(Button.transform) < -VISIBILITY_THRESHOLD)
            {
                ButtonSelected = Button;
                ShowWatchedButton(Button);
            }
            else
            {
                HideNonWatchedButton(Button);
            }
        }

        // Update UI
        if (ButtonSelected != null)
        {
            keyboardPanel.GetComponent<KeyBoardManager>().IndicateKeyStart("use");
        }
        else
        {
            keyboardPanel.GetComponent<KeyBoardManager>().IndicateKeyStop("use");
        }

        // Push button
        if ((Input.GetKey(KeyCode.E)) && (ButtonSelected != null))
        {
            if ((ButtonSelected == buttons[0])) //Confirm button
            {
                //FreeMovement();
                //ButtonSelected.GetComponent<ButtonPushed>().CallThisFromButton();
            }
            if ((ButtonSelected == buttons[1]))
            {
                Debug.Log("J APPUIE SUR LE GROS BOUTON ROUGE");
                ButtonSelected.GetComponent<ButtonPushed>().CallThisFromButton();
            }
            
            if ((ButtonSelected == buttons[2]))
            {

                //ButtonSelected.GetComponent<ButtonPushed>().CallThisFromButton();
            }
        }
    }

    private void ShowWatchedButton(GameObject Button)
    {
        Color CurrentColor = Button.transform.GetComponent<Renderer>().material.color;
        CurrentColor = Color.green;
        Button.transform.GetComponent<Renderer>().material.color = CurrentColor;
    }

    private void HideNonWatchedButton(GameObject Button)
    {
        Color CurrentColor = Button.transform.GetComponent<Renderer>().material.color;
        CurrentColor = Color.red;
        Button.transform.GetComponent<Renderer>().material.color = CurrentColor;
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    private float GetTargetGameObjectVisibility(Transform Target)
    {
        Vector3 dirFromAtoB = (transform.position - Target.position).normalized;
        return Vector3.Dot(dirFromAtoB, transform.forward);
    }

    private void FreeYAxis()
    {
        mousePanel.ShowArrow("up");
        mousePanel.ShowArrow("down");
        GetComponent<Movement>().AllowCameraX = true;
        mousePanel.IndicateArrow("up");
        mousePanel.IndicateArrow("down");
    }

    private void FreeMovement()
    {
        //mousePanel.ShowArrow("up");
        //mousePanel.ShowArrow("down");
        GetComponent<Movement>().AllowMovement = true;
        //mousePanel.IndicateArrow("up");
        //mousePanel.IndicateArrow("down");
    }
}
