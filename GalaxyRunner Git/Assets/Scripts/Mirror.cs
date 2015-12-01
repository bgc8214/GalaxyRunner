using UnityEngine;
using System.Collections;

public class Mirror : MonoBehaviour {
    public GameObject explosion;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            GameObject effect = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
            GameObject reflect = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            reflect.GetComponent<Rigidbody>().velocity = -other.GetComponent<Rigidbody>().velocity;
            Destroy(other);
            Destroy(effect, 2);
        } 
    }
}
