using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour{

    public Timer gameTime;
    public float timeValue = 2.0f;

    private AudioSource coinSound;

    void Start(){
        coinSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            coinSound.Play();
            if (gameTime != null){
                gameTime.IncreaseTime(timeValue);
            }
            
            Destroy(gameObject, coinSound.clip.length - 0.1f);
        }
    }
}
