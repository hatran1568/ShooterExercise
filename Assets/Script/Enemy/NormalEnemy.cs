using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    private Vector3 _targetPosition;
    private void Awake()
    {
        blood = 1;
    }

    void Start()
    {
        _targetPosition = GameObject.Find("/Turret").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
    }
}
