using UnityEngine;
using System.Collections;

public class HeadMove : MonoBehaviour {
    public float Range;

    private float x;
    private float tilt;
    private Transform tf;
	// Use this for initialization
	void Start () {
        tf = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        tilt = Cardboard.SDK.HeadPose.Orientation.eulerAngles.z;
        Debug.Log("eulerAngles.z:" + tilt.ToString());
        
        if (tilt >= 270)
        {
            x = Range*(360 - tilt) / 90f;
        }
        else if (tilt <= 90)
        {
            x = -Range*(tilt / 90f);
        }

        tf.position = new Vector3(x, 0, 0);
	}
}
