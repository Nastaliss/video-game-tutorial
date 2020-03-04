using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 3f; 
    private float sensitivity = 100f; 

    public GameObject CameraRig;    
    private float BaseVerticalPos;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log('a');
        BaseVerticalPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 pos = transform.localPosition;

        if (Input.GetKey ("w")) {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
         }
        if (Input.GetKey ("s")) {
            transform.localPosition -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey ("d")) {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey ("a")) {
            transform.localPosition -= transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown("space") && pos.y <= BaseVerticalPos) {
            Debug.Log("space");
        rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }

        float inputX = Input.GetAxis("Mouse Y") * 5f ;
        inputX = CameraRig.transform.localEulerAngles.x - inputX;

        CameraRig.transform.localEulerAngles = new Vector3(inputX,0,0);

        if (CameraRig.transform.localEulerAngles.x > 90f && CameraRig.transform.localEulerAngles.x < 180f) {
            CameraRig.transform.localEulerAngles = new Vector3(90, 0, 0) ;
        } else if (CameraRig.transform.localEulerAngles.x >= 180f && CameraRig.transform.localEulerAngles.x < 270f) {
            CameraRig.transform.localEulerAngles =new Vector3(270, 0, 0);
        }



        // float rotX = 0, rotY = 0;
        // if (Input.GetAxis("Mouse Y") < 0) {
        //     rotX++;
        // }
        // if (Input.GetAxis("Mouse Y") > 0) {
        //     rotX--;
        // }
        // if (Input.GetAxis("Mouse X") < 0) {
        //     rotY--;
        // }
        // if (Input.GetAxis("Mouse X") > 0) {
        //     rotY++;
        // }

        // CameraRig.transform.Rotate(new Vector3(rotX, 0, 0), sensitivity * Time.deltaTime);
        
        // Debug.Log(CameraRig.transform.rotation.x);

        // CameraRig.transform.rotation = Quaternion.EulerAngles( Mathf.Clamp( CameraRig.transform.rotation.x, -0.5f, 0.5f),0,0);
        // if (CameraRig.transform.localEulerAngles.x > 90f && CameraRig.transform.localEulerAngles.x < 180f) {
        //     CameraRig.transform.rotation.SetEulerAngles(new Vector3(90, 0, 0));
        // } else if (CameraRig.transform.localEulerAngles.x >= 180f && CameraRig.transform.localEulerAngles.x < 270f) {
        //     CameraRig.transform.rotation.SetEulerAngles(new Vector3(270, 0, 0));
        // }
    }
}
