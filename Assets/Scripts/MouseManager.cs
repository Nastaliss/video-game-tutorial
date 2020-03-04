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
        HideArrow(ArrowUp);
        HideArrow(ArrowRight);
        HideArrow(ArrowDown);
        HideArrow(ArrowLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowArrow(Image Arrow) {
        Arrow.enabled = true;
    }

    public void HideArrow(Image Arrow) {
        Arrow.enabled = false;
    }

}
