using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject explosion;
    public int blood;

    private void Awake()
    {
        
    }
    
    public virtual void OnCollisionOperation(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("turret"))
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.tag.Equals("bullet"))
        {
            blood--;
            if (blood <= 0)
            {
                Object.Instantiate<GameObject>(explosion, gameObject.transform.position, Quaternion.identity);
                //Helper.GetGameMonitor().Score += 1;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionOperation(collision);
    }
}
