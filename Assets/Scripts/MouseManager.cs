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

    public float DeadZoneX = 2f;
    public float DeadZoneY = .5f;

    private float PreviousAngleY;
    private float PreviousAngleX;

    private Coroutine UseUpCouroutine;
    private Coroutine UseRightCouroutine;
    private Coroutine UseDownCouroutine;
    private Coroutine UseLeftCouroutine;

    void Start()
    {
        // HideArrow("up");
        // HideArrow("right");
        // HideArrow("down");
        // HideArrow("left");
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
        if (Mathf.Abs(Input.GetAxis("Mouse Y")) > DeadZoneY / 4) {
            ResetArrowColor("up");
            ResetArrowColor("down");
            if (UseUpCouroutine != null) StopCoroutine(UseUpCouroutine);
            if (UseDownCouroutine != null) StopCoroutine(UseDownCouroutine);
        }

        if (Input.GetAxis("Mouse Y") > DeadZoneY / 4) {
            UseUpCouroutine = UseArrow("up");
        } else if (Input.GetAxis("Mouse Y") < - DeadZoneY / 4) {
            UseDownCouroutine = UseArrow("down");
        }

        if (Mathf.Abs(Input.GetAxis("Mouse X")) > DeadZoneX) {
            
            ResetArrowColor("right");
            ResetArrowColor("left");
            if (UseRightCouroutine != null) StopCoroutine(UseRightCouroutine);
            if (UseLeftCouroutine != null)  StopCoroutine(UseLeftCouroutine);
        }

        if (Input.GetAxis("Mouse X") > DeadZoneX) {
            UseRightCouroutine = UseArrow("right");
        } else if (Input.GetAxis("Mouse X") < - DeadZoneX) {
            UseLeftCouroutine = UseArrow("left");
        }

    }

    public void ShowArrow(string ArrowDirection) {
        GetArrow(ArrowDirection).enabled = true;
    }

    public void HideArrow(string ArrowDirection) {
        GetArrow(ArrowDirection).enabled = false;
    }

    public void ResetArrowColor(string ArrowDirection) {
        GetArrow(ArrowDirection).color = new Color(0f, 0f, 0f);;
    }

    public void IndicateArrow(string ArrowDirection) {
        StartCoroutine(IndicateCoroutine(GetArrow(ArrowDirection), 2f));
    }

    public Coroutine UseArrow(string ArrowDirection) {
        return StartCoroutine(ArrowUseCoroutine(GetArrow(ArrowDirection), 2f));
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

    IEnumerator ArrowUseCoroutine(Image Arrow, float TimeSeconds) {
        Arrow.color = new Color(0f, 1f, 0f);
        yield return new WaitForSeconds(.5f);
        Arrow.color = new Color(0f, 0f, 0f);
    }
}
