using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour
{
	public GameObject shot;		
	public Transform firePostion;
    public float fireTime = 1;
    public float repeatRate = 2;

	void Start () 
	{
		InvokeRepeating ("Fire", fireTime, repeatRate);
	}
	void Fire(){

        Instantiate(shot, firePostion.position, firePostion.rotation);

	}
	

}
