using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball"))
        {
            if(Mathf.Abs(other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude) < 5f)
            {
                if(SceneManager.GetActiveScene().buildIndex == 7)
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
