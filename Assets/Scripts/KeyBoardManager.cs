using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyBoardManager : MonoBehaviour
{
    public Key ForwardKey;
    public Key RightKey;
    public Key BackwardKey;
    public Key UseKey;
    public Key LeftKey;
    public Key SpaceKey;
    public Key CrouchKey;
    public Key WalkKey;

    void Start()
    {
        IndicateKeyStart("forward");
    }

    void Update()
    {
        UpdateKey(ForwardKey, new KeyCode[] {KeyCode.Z, KeyCode.W});
        UpdateKey(RightKey, new KeyCode[] {KeyCode.D});
        UpdateKey(BackwardKey, new KeyCode[] {KeyCode.S});
        UpdateKey(LeftKey, new KeyCode[] {KeyCode.Q, KeyCode.A});
        UpdateKey(UseKey, new KeyCode[] {KeyCode.E});
        UpdateKey(SpaceKey, new KeyCode[] {KeyCode.Space});
        UpdateKey(CrouchKey, new KeyCode[] {KeyCode.LeftControl, KeyCode.LeftCommand});
        UpdateKey(WalkKey, new KeyCode[] {KeyCode.LeftShift});
        
    }

    void UpdateKey(Key KeyElement, KeyCode[] KeyButtonMapping) {

        foreach(KeyCode KeyButton in KeyButtonMapping) {
            if(Input.GetKey(KeyButton)) {
                KeyElement.OnKeyPressed();
                return;
            }
        }

        KeyElement.OnKeyReleased();
    }

    private Key GetKey(string KeyAction) {
        switch (KeyAction) {
            case "forward":
                return ForwardKey;
            case "right":
                return RightKey;
            case "backward":
                return BackwardKey;
            case "left":
                return LeftKey;
            case "use":
                return UseKey;
            case "crouch": 
                return CrouchKey;
            case "walk":
                return WalkKey;
            default:
                throw new Exception("Key " + KeyAction + " not found");
        }
    }

    public void IndicateKeyStart(string KeyName) {
        GetKey(KeyName).BlinkHighlightStart();
    }

    public void IndicateKeyStop(string KeyName) {
        GetKey(KeyName).BlinkHighlightStop();
    }


    

}
