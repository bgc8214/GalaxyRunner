using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
    public GameObject explosion;
    public GameObject frame;
    public StartAnimation ani;    
	// Use this for initialization
	void Start () {
        frame.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 4, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Cardboard.SDK.Triggered)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
            ani = GameObject.Find("CardboardHead").GetComponent<StartAnimation>();
            ani.flag = true;     
            //GameObject mExplosion = Instantiate(explosion);
            //Destroy(mExplosion, 3);
            Destroy(gameObject);
           // Application.LoadLevelAsync("Main");
        }
	}
}
