using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Timer gameTime;
    //public GameObject LostScreen;
    //public AudioSource music;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            gameTime.IncreaseTime(-30.0f);
            //wonScreen.SetActive(true);
            //music.Stop();
            //Destroy(gameObject);
        }
    }
}
