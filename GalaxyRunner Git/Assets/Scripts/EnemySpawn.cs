using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    public GameObject[] hazards;
    public float startWait = 1;
    public float spawnWait = 0.75f;
    public float waveWait = 2;
    public float spawnPoint = 120.0f;

    private GameObject player;
    private ArrayList stageHazard;
    private int[][] stageTable = new int[10][];

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        InitStageTable();
        changeStage(0);
        StartCoroutine(SpawnWaves());
    }

    private void InitStageTable()
    {
        Debug.Log("====InitStageTable");
        stageTable[0] = new int[] { 0, 1, 2 };
        stageTable[1] = new int[] { 0, 1, 2, 4 };
        stageTable[2] = new int[] { 0, 1, 2, 3, 7 };
        stageTable[3] = new int[] { 3, 4 };
        stageTable[4] = new int[] { 0, 1, 2, 5, };
        stageTable[5] = new int[] { 4, 5, 7};
        stageTable[6] = new int[] { 0, 1, 2, 4, 6 };
        stageTable[7] = new int[] { 4, 5, 6, 7 };
        stageTable[8] = new int[] { 0, 1, 2, 3, 4, 5, 6};
        stageTable[9] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        return;
    }

    public void changeStage(int stage)
    {
        // setting hazards for the stage
        Debug.Log("====changeStages");
        stageHazard = new ArrayList();
        foreach (int idx in stageTable[stage])
        {
            stageHazard.Add(hazards[idx]);
            Debug.Log("added:" + idx);
        }
        switch (stage) // spawning portals once in stage
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
                Vector3 spawnPosition =
                    new Vector3(Random.Range(-5, 5), player.transform.position.y, spawnPoint);
                Quaternion spawnRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                Instantiate(hazards[8], spawnPosition, spawnRotation);
                break;
            default:
                break;
        } // End of switch
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (player != null)
        {
            for (int i = 0; i < 10; ++i)
            {
                GameObject hazard = (GameObject)stageHazard[(int)Random.Range(0,stageHazard.Count)];
                Vector3 spawnPosition =
                    new Vector3(Random.Range(-5, 5), player.transform.position.y, spawnPoint);
                Quaternion spawnRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        } // End of while
    } // End of SpawnWaves

}
