using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class CameraManager : MonoBehaviour
{
	static CameraManager _instance;
    public static CameraManager Instance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CameraManager>();
            }
            return _instance;
        }
    }

    private Transform CameraMenu;

	private float y=0;
	private Vector3 rotateValue;


    private void RotateCameraMenu(){
    	y=y+0.1f;
    	rotateValue = new Vector3(0, y, 0);
    	CameraMenu.eulerAngles=rotateValue;
    }


    // Start is called before the first frame update
    void Start()
    {
        CameraMenu=GameObject.Find("CameraMenu").GetComponent<Transform>();
        rotateValue = new Vector3(0, 0, 0);
    	CameraMenu.eulerAngles=rotateValue;
    }

    // Update is called once per frame
    void Update()
    {
       RotateCameraMenu();
    }
}
