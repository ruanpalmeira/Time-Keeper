using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : MonoBehaviour{
    
    public GameObject wonScreen;
    public AudioSource music;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            wonScreen.SetActive(true);
            music.Stop();
            Destroy(gameObject);
        }
    }

}
