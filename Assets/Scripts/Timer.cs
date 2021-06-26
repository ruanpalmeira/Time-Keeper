using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{

    public float time = 60.0f;
    public Text timeText;
    public GameObject Play, Pause, Won, Lost;
    public AudioSource music;

    private float maxTime;

    void Start(){
        timeText.text = time.ToString("#");
        maxTime = time;
    }

    void FixedUpdate(){
        if(!Play.activeSelf && !Pause.activeSelf && !Lost.activeSelf && !Won.activeSelf){
            time -= Time.deltaTime;
            timeText.text = time.ToString("#");
        }

        if (time < 0){
            time = 0;
            Lost.SetActive(true);
            music.Stop();
        }
    }

    public void IncreaseTime(float value){
        time += value;
        time = Mathf.Clamp(time, 0.0f, maxTime);
    }
}
