using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : Enemy
{
    public float spawnInterval;
    [SerializeField]
    GameObject childEnemy;

    private Vector3 _targetPosition;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = spawnInterval;
        timer.Run();
        _targetPosition = GameObject.Find("/Turret").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);

        if (timer.Finished)
        {
            Instantiate<GameObject>(childEnemy, transform.position, Quaternion.identity);
            timer.Run();
        }
    }
}
