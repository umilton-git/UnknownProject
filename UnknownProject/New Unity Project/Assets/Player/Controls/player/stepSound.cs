using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays the stepping sound.
/// </summary>
public class stepSound : MonoBehaviour
{
    public AudioClip footStep;
    public AudioSource audioS;

    void FootStep()
    {
        audioS.PlayOneShot(footStep);
    }
}
