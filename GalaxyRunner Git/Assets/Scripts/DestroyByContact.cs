using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
    public float damage = 10;
    public int bonus = 10;
    public int destroyCount = 1;

    GameController gameController;
    GameObject player;


	void Start ()
	{
		gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController>();
        player = GameObject.FindWithTag("Player");
	}

	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "UI")
        {
            return;
        }
        else if (other.tag == "Player")
        {
            GameObject mExplosion = (GameObject) Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(mExplosion, 3);
            other.SendMessage("Damaged", damage);
            destroyCount = 0;
        }
        else if (other.tag == "Bullet")
        {
            Destroy(other);
            gameController.destroyScore += bonus;
            gameController.destroyCount++;
            destroyCount--;
        }

        // Explosion itself and Destroy itself
        if (explosion != null)
        {
            GameObject mExplosion = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
            Destroy(mExplosion, 3);
        }
        if(destroyCount == 0 ) Destroy (gameObject);
	}


}
