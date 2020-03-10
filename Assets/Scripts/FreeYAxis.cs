using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeYAxis : MonoBehaviour
{

    public GameObject character;
    public GameObject chainOne;
    public GameObject chainTwo;
    public GameObject chainThree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        CheckActive();
    }

    public void CheckActive()
    {
        if ((chainOne == null) && (chainTwo == null) && (chainThree == null))
        {
            character.GetComponent<Movement>().AllowCameraX = true;
        }
    }


}
