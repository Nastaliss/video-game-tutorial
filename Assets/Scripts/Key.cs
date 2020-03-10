using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    public Image KeyImageElement;

    public Text KeyTextElement;

    public string DefaultText;

    private Color ColorDefault = new Color(1f, 1f, 1f);
    private Color ColorPressed = new Color(.9f, .47f, .4f);
    private Color ColorHighlighted = new Color(0f, .53f, 1f);

    void Start() {
        ResetText();
        ChangeColor(ColorDefault);
    }
    // COLOR //
    private void ChangeColor(Color color) {
        KeyImageElement.color = color;
    }
    public void OnKeyPressed() {
        ChangeColor(ColorPressed);
    }

    public void OnKeyReleased() {
        if (KeyImageElement.color != ColorHighlighted) {
            ChangeColor(ColorDefault);
        }
    }

    public void OnKeyHighlight() {
        ChangeColor(ColorHighlighted);
    }

    public void OnKeyDehighlight() {
        ChangeColor(ColorDefault);
    }

    // TEXT //
    public void SetText(string text) {
        KeyTextElement.text = text;
    }
    public void ResetText() {
        SetText(DefaultText);
    }
}
