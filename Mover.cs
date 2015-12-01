using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	    public float speed = 5;

	    void Start () 
	    {
        
            GetComponent<Rigidbody> ().velocity = Vector3.forward * speed;
      
                
	    }


}
		