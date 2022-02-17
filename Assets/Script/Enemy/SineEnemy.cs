using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineEnemy : Enemy
{
    public float amplitude;
    private float distance;
    private float angle;
    private void Awake()
    {
        Vector3 _targetPosition = GameObject.Find("/Turret").transform.position;
        distance = -Vector3.Distance(transform.position, _targetPosition);
        angle = Mathf.Atan2(transform.position.y - _targetPosition.y, transform.position.x - _targetPosition.x);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(transform.position.x + Mathf.Cos(angle + Mathf.Sin(Time.time * 3) * amplitude) * distance * Time.deltaTime * speed /10,
                                transform.position.y + Mathf.Sin(angle + Mathf.Sin(Time.time * 3) * amplitude) * distance * Time.deltaTime * speed / 10, 0);
        transform.position = vector;
       
    }
}
