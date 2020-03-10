using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Image ArrowUp;
    public Image ArrowRight;
    public Image ArrowDown;
    public Image ArrowLeft;

    private float PreviousAngleY;
    private float PreviousAngleX;



    void Start()
    {
        HideArrow("up");
        HideArrow("right");
        HideArrow("down");
        HideArrow("left");
    }

    // Update is called once per frame
    void Update()
    {
        ShowArrowWhenCameraMoves();
    }

    private Image GetArrow(string ArrowIndicator) {
        switch (ArrowIndicator) {
            default:
            case "up":
                return ArrowUp;
            case "right":
                return ArrowRight;
            case "down":
                return ArrowDown;
            case "left":
                return ArrowLeft;
        }

    }

    private void ShowArrowWhenCameraMoves() {
        // if (Input.GetAxis("Mouse Y") > 0) {
        //     UseArrow("up");
        // } else if (Input.GetAxis("Mouse Y") < 0) {

        // }

    }

    public void ShowArrow(string ArrowDirection) {
        GetArrow(ArrowDirection).enabled = true;
    }

    public void HideArrow(string ArrowDirection) {
        GetArrow(ArrowDirection).enabled = false;
    }

    public void IndicateArrow(string ArrowDirection) {
        StartCoroutine(IndicateCoroutine(GetArrow(ArrowDirection), 2f));
    }

    public void UseArrow(string ArrowDirection) {
        StartCoroutine(UseCoroutine(GetArrow(ArrowDirection), 2f));
    }

    IEnumerator IndicateCoroutine(Image Arrow, float TimeSeconds) {
        var endTime=Time.time + TimeSeconds;
        while(Time.time < endTime) {
            Arrow.color = new Color(1f, 0f, 0f);
            yield return new WaitForSeconds(0.2f);
            Arrow.color = new Color(0f, 0f, 0f);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator UseCoroutine(Image Arrow, float TimeSeconds) {
        Arrow.color = new Color(0f, 1f, 0f);
        yield return new WaitForSeconds(1f);
        Arrow.color = new Color(0f, 0f, 0f);
    }
}
