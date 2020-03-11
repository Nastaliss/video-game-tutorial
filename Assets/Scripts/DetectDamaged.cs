using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDamaged : MonoBehaviour
{
    public float viewRadius;

    [Range(0, 360)]
    public float viewAngle;

    public GameObject keyboardPanel;
    public MouseManager mousePanel;


    public List<GameObject> chains;

    private float VISIBILITY_THRESHOLD = .9f; 
    public List<Transform> visibleDmgs = new List<Transform>(); 

    void Start() {
        mousePanel.HideArrow("down");
        mousePanel.HideArrow("up");

        mousePanel.IndicateArrow("left");
        mousePanel.IndicateArrow("right");

    }

    void Update() {
        // TODO: Break down in smaller functions
        GameObject ChainSelected = null;
        
        foreach (GameObject Chain in chains) {

            if (GetTargetGameObjectVisibility(Chain.transform.GetChild(1)) < - VISIBILITY_THRESHOLD) {
                ChainSelected = Chain;
                ShowChainDamageSphere(Chain);
            } else {
                HideChainDamageSphere(Chain);
            }
        }

        // Update UI
        if (ChainSelected != null) {
            keyboardPanel.GetComponent<KeyBoardManager>().IndicateKeyStart("use");
        } else { 
            keyboardPanel.GetComponent<KeyBoardManager>().IndicateKeyStop("use");
        }

        // Break and delete chain
        if ((Input.GetKey(KeyCode.E)) && (ChainSelected != null)) {
            ChainSelected.GetComponent<ChainFalling>().CallThisFromButton(ChainSelected);
            chains.Remove(ChainSelected);
            if (chains.Count == 0) {
                FreeYAxis();
            }
        }
    }

    private void ShowChainDamageSphere(GameObject Chain) {
        Color CurrentColor = Chain.transform.GetChild(1).GetComponent<Renderer>().material.color;
        CurrentColor.a = .42f;
        Chain.transform.GetChild(1).GetComponent<Renderer>().material.color = CurrentColor;
    }

    private void HideChainDamageSphere(GameObject Chain) {
        Color CurrentColor = Chain.transform.GetChild(1).GetComponent<Renderer>().material.color;
        CurrentColor.a = .0f;
        Chain.transform.GetChild(1).GetComponent<Renderer>().material.color = CurrentColor;
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y; 
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    private float GetTargetGameObjectVisibility(Transform Target) {
        Vector3 dirFromAtoB = (transform.position - Target.position).normalized;
        return Vector3.Dot(dirFromAtoB, transform.forward);
    }

    private void FreeYAxis() {
        mousePanel.ShowArrow("up");
        mousePanel.ShowArrow("down");
        GetComponent<Movement>().AllowCameraX = true;
        mousePanel.IndicateArrow("up");
        mousePanel.IndicateArrow("down");
    }
}
