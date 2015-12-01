using UnityEngine;
using System.Collections;

public class DestroyGarbage : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.ToString() + " destroyed");
        Destroy(other);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
