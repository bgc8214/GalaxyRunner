using UnityEngine;
using System.Collections;

public class ItemBox : MonoBehaviour {
    public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerWeapon>().weapon_num = 1;
            other.GetComponent<PlayerWeapon>().bullet = 10;
            GameObject mExplosion = (GameObject) Instantiate(explosion, other.GetComponent<Transform>().position, other.GetComponent<Transform>().rotation);
            Destroy(gameObject);
            Destroy(mExplosion, 2);
        }
    }
}
