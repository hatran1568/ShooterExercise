using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //death support for explosion
    Timer explosionTimer;
    const float explosionDuration = 1;
    private AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        //create explosion timer
        explosionTimer = gameObject.AddComponent<Timer>();
        //start explosion timer
        explosionTimer.Duration = explosionDuration;
        explosionTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // stop explosion explosion timer finished
        if (explosionTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
