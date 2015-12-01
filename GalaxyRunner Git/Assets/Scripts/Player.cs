using UnityEngine;

public class Player : MonoBehaviour
{
    public float power = 100;
    public float xSpeed = 10;
    public float xRange = 5;
    public float xSteering = 1;

    private Ray mRay;
    private Vector3 diffPosition;
    private GameObject mBullet;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {

        diffPosition = Vector3.zero;
        if (GameObject.Find("GameController") != null)
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        mRay = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CardboardHead>().Gaze;
        //Debug.Log(mRay + " : " + mRay.direction.x + " is x");
        diffPosition.x = mRay.direction.x * xSpeed;

        // move obect in range
        gameObject.transform.position =
            new Vector3(
                Mathf.Abs(diffPosition.x) <= xRange ? diffPosition.x : (diffPosition.x >= 0 ? xRange : -xRange),
                gameObject.transform.position.y,
                gameObject.transform.position.z);

        // steering
        gameObject.transform.right = new Vector3(1, mRay.direction.x * xSteering, 0);
    }

    void Damaged(float amount)
    {
        power -= amount;
        if (power <= 0)
        {
            GameObject.FindGameObjectWithTag("GameController").SendMessage("GameOver");
            Destroy(gameObject);
            Destroy(gameController.HPBar);
        }
        else if (power >= 100)
        {
            power = 100;
        }
    }
}