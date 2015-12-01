using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {
    public GameObject[] weapon;
    public GameObject FirePosition;
    public int weapon_num = 0;
    public int bullet = 5;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // magnetic sensor
        if (Cardboard.SDK.Triggered)
        {
            Instantiate(weapon[weapon_num], FirePosition.transform.position, weapon[weapon_num].transform.rotation);
            if (weapon_num != 0) bullet--;
            if (bullet == 0) weapon_num = 0;
        }
    }
}
