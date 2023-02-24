using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullFlipSound : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    float   rotation = 0;
    bool    isPlayingSound = false;
    private float initialRotation;
    void Start()
    {
        initialRotation = this.transform.rotation.z;
    }
    void Update()
    {
        rotation = Mathf.Abs(initialRotation - this.transform.rotation.z);
        if (rotation >= 0.9 && !isPlayingSound)
        {
            isPlayingSound = true;
            AudioSource.PlayClipAtPoint(sound, this.transform.position);
        }
        else if (rotation <= 0.5 && isPlayingSound)
        {
            isPlayingSound = false;
        }
    }
}
