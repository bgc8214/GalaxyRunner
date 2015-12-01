using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {

    public float timer = 3;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timer);
    }
}
