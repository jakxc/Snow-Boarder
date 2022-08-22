using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    private float delayTime = 2f;
    
    [SerializeField]
    private ParticleSystem crashEffect;

    [SerializeField]
    private AudioClip crashSFX;

    private bool hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed) {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisablePlayer();

            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delayTime);
        }
    }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
