using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
