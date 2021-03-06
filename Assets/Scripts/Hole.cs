using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains.Feedbacks;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    
    private AudioSource audio;

    private void Start() {
        audio = GameObject.FindGameObjectWithTag("HoleAudio").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball"))
        {
            if(Mathf.Abs(other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude) < 10f)
            {
                audio.Play();
                if(SceneManager.GetActiveScene().buildIndex == 9)
                    LoadMainMenu();
                else
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }      
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
