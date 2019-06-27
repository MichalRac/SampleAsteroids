using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private float Lifetime = 2.0f;
    [SerializeField] private AudioClip audioToPlay;

    private void Awake()
    {
        if(audioToPlay != null)
        {
            AudioManager.Instance.PlaySound(audioToPlay);
        }
        Destroy(gameObject, Lifetime);
    }
}
