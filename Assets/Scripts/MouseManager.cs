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

    void Start()
    {
        // HideArrow("up");
        HideArrow("right");
        HideArrow("down");
        HideArrow("left");
        IndicateArrow("up");
    }

    // Update is called once per frame
    void Update()
    {

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
    public void ShowArrow(string ArrowDirection) {
        GetArrow(ArrowDirection).enabled = true;
    }

    public void HideArrow(string ArrowDirection) {
        GetArrow(ArrowDirection).enabled = false;
    }

    public void IndicateArrow(string ArrowDirection) {
        StartCoroutine(Indicate(GetArrow(ArrowDirection), 2f));
    }

    IEnumerator Indicate(Image Arrow, float TimeSeconds) {
        var endTime=Time.time + TimeSeconds;
        Debug.Log(Time.time);
        Debug.Log(endTime);
        while(Time.time < endTime) {
            Arrow.color = new Color(1f, 0f, 0f);
            yield return new WaitForSeconds(0.2f);
            Arrow.color = new Color(0f, 0f, 0f);
            yield return new WaitForSeconds(0.2f);
        }
    }

}
