using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 0.7f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool isPlaying = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<PlayerController>().DisableControls();
        if (other.tag == "Ground")
        {
            if (!isPlaying)
            {
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                isPlaying = true;
            }
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
