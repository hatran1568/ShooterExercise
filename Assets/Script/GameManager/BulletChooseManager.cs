using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletChooseManager : MonoBehaviour
{
    public Button defaultBullet;
    public Button scatterBullet;
    public Button consecutiveBullet;

    // Start is called before the first frame update
    void Start()
    {
        defaultBullet.onClick.Invoke();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            defaultBullet.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            scatterBullet.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            consecutiveBullet.onClick.Invoke();
        }
    }
}
