using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    public float speed = 5;

    void Start()
    {

        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
       

    }
    void FixedUpdate()
    {
        float tilt = Cardboard.SDK.HeadPose.Orientation.eulerAngles.z;

        print(tilt + "");
        if (tilt>0)
        {
            //Debug.Log(" " + this.transform.rotation.z);
            //transform.Translate(new Vector3(-0.05f, 0,0 ));  
            transform.Translate(Vector3.left*0.05f, Space.World);
        }
        else if (this.transform.rotation.z < 0)
        {
           // transform.Translate(new Vector3(0.05f, 0, 0));
            transform.Translate(Vector3.right * 0.05f, Space.World);
            //Debug.Log("dddd ");
        }
       

       

      

    }



}
