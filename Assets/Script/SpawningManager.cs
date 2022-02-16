using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [SerializeField]
    GameObject normalEnemy;
    [SerializeField]
    GameObject sineEnemy;
    [SerializeField]
    GameObject bigEnemy;
    public int DurationToSpawn = 2;

    Timer spawningTimer;
    Dictionary<int, GameObject> spawningLocations = new Dictionary<int, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spawningTimer = gameObject.AddComponent<Timer>();
        spawningTimer.Duration = DurationToSpawn;
        spawningTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawningTimer.Finished)
        {

            int random_index_location = Random.Range(1, 4);
            int edge = Random.Range(0, 4);
            Vector3 spawnPosition = new Vector3(Random.Range(-11, 11), 6, 1);
            switch (edge)
            {
                case 0:
                    spawnPosition = new Vector3(Random.Range(-11, 11), 6, 1);
                    break;
                case 1:
                    spawnPosition = new Vector3(Random.Range(-11, 11), -6, 1);
                    break;
                case 2:
                    spawnPosition = new Vector3(11, Random.Range(-6, 6), 1);
                    break;
                case 3:
                    spawnPosition = new Vector3(-11, Random.Range(-6, 6), 1);
                    break;
            }
            int enemyType = Random.Range(0, 3);
            switch (enemyType)
            {
                case 0:
                    Instantiate<GameObject>(normalEnemy, spawnPosition, Quaternion.identity);
                    break;
                case 1:
                    Instantiate<GameObject>(sineEnemy, spawnPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate<GameObject>(bigEnemy, spawnPosition, Quaternion.identity);
                    break;

            }
            
            spawningTimer.Run();
        }
    }
}
