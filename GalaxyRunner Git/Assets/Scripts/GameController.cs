using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    public GameObject HPBar;
    public GameObject ScoreBar;
    public GameObject retry;

    
    public int distancePoint = 10;
    public float fuelPerSec = 1.0f;
    public float scorePerSec = 1.0f;
    public int destroyCount = 0;
    public int destroyScore = 0;

    private bool flagRetry = false;
    private GameObject player;
    private int distanceScore = 0;
    private int stage = 0;

    

	void Start ()
	{
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Score());
        StartCoroutine(Fuel());
        //play BGM
        GetComponent<AudioSource>().Play();
    }
	
	void Update () 
	{
        if(ScoreBar != null) ScoreBar.GetComponent<TextMesh>().text = (distanceScore + destroyScore).ToString();
        //Debug.Log("distance:" + distanceScore.ToString() + "destroycount: " + destroyCount.ToString());
        if (player == null && Cardboard.SDK.Triggered) flagRetry = true;
    }

    void GameOver ()
    {
        Destroy(HPBar);
        StartCoroutine(Retry());
    }

    IEnumerator Fuel()
    {
        while(player != null)
        {
            player.SendMessage("Damaged", 1);
            yield return new WaitForSeconds(fuelPerSec);
        }
    }

    IEnumerator Score()
    {
        while(player != null)
        {
            distanceScore++;
            if (stage == 0 && distanceScore > 30)
            {
                stage++;
                gameObject.GetComponent<EnemySpawn>().changeStage(stage);
            }
            else if ((distanceScore - 30) % 45 == 0)
            {
                stage++;    
                Debug.Log("==========StageChanged");
                gameObject.GetComponent<EnemySpawn>().changeStage(stage);
            }
            yield return new WaitForSeconds(scorePerSec);
        }
    }
    IEnumerator Retry()
    {
        Destroy(ScoreBar);
        GameObject mRetry = Instantiate(retry);
        mRetry.GetComponentInChildren<TextMesh>().text = (distanceScore + destroyScore).ToString();
        
        while (!flagRetry)
        {
            mRetry.GetComponent<Rigidbody>().velocity = Vector3.up * 0.2f;
            yield return new WaitForSeconds(0.5f);
            mRetry.GetComponent<Rigidbody>().velocity = Vector3.down * 0.2f;
            yield return new WaitForSeconds(0.5f);
        }
        Application.LoadLevelAsync("Main");
    }
}
