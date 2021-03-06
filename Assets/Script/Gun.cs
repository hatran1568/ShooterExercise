using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform orb;
    public float radius;
    public GameObject bulletPrefab;
    private AudioSource audioData;
    private BulletType bulletType = BulletType.DEFAULT;
    private Transform pivot;

    void Start()
    {
        pivot = orb.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
    }

    void Update()
    {
        Vector3 orbVector = Camera.main.WorldToScreenPoint(orb.position);
        orbVector = Input.mousePosition - orbVector;
        float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

        pivot.position = orb.position;
        pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (bulletType)
            {
                case BulletType.DEFAULT:
                    {
                        SpawnBullet(0, 1);
                        SpawnBullet(0, 1);
                        SpawnBullet(0, 1);
                        break;
                    }
                case BulletType.SCATTER:
                    {
                        SpawnBullet(0, 1);
                        SpawnBullet(-15, 1);
                        SpawnBullet(15, 1);
                        break;
                    }
                case BulletType.CONSECUTIVE:
                    {
                        SpawnBullet(0, 3);
                        break;
                    }
            }

            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
        }

    }

    public void ChooseBulletDefault()
    {
        bulletType = BulletType.DEFAULT;

    }
    public void ChooseBulletScatter()
    {
        bulletType = BulletType.SCATTER;

    }
    public void ChooseBulletConsecutive()
    {
        bulletType = BulletType.CONSECUTIVE;

    }
    private void SpawnBullet(float customAngle, int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 bulletPosition = new Vector3(transform.position.x * (2+i), transform.position.y * (2+i), 0);
            GameObject bullet = Instantiate<GameObject>(bulletPrefab, bulletPosition, gameObject.transform.rotation);
            bullet.tag = "bullet";
            Rigidbody2D bullet_body = bullet.GetComponent<Rigidbody2D>();

            Bullet bullet_script = bullet.GetComponent<Bullet>();
            bullet_body.AddForce(Helper.getVector2DByDegree(-transform.eulerAngles.z + customAngle) * bullet_script.Impulse, ForceMode2D.Force);
        }

    }
}
