using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<Ball>().Hits = GameObject.FindGameObjectWithTag("Manager").GetComponent<HitsTracker>().MaxHits;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
