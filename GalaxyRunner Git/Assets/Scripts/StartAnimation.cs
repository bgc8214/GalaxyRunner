using UnityEngine;
using System.Collections;

public class StartAnimation : MonoBehaviour {

    public float speed = 1.0f;
    public bool flag = false;
	
	// Update is called once per frame
	void Update ()
    {
        if(flag == true)
        {
            move();
        }
	}
    public void move()
    {
        if (transform.position.z < 4.7)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            Application.LoadLevelAsync("Main");
        }

    }
}
