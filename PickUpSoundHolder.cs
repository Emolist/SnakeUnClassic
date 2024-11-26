using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSoundHolder : MonoBehaviour
{
    public AudioSource source;

    public AudioClip[] fruitPickUps;
    public AudioClip heartPickUp;
    public AudioClip spikeSound;
    public AudioClip obstacleSound;

    public void RandomFruitSound()
    {
        source.clip = fruitPickUps[Random.Range(0, fruitPickUps.Length)];
        source.Play();
    }

    public void ObstacleSoundPlay()
    {
        source.clip = obstacleSound;
        source.Play();
    }

    public void HearthSoundPlay()
    {
        source.clip = heartPickUp;
        source.Play();
    }

    public void SpikeSoundPlay()
    {
        source.clip = spikeSound;
        source.Play();
    }
}
