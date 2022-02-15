using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public GameObject explosion;
    private Vector3 _targetPosition;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _targetPosition = GameObject.Find("/Turret").transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate<GameObject>(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
