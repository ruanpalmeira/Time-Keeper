using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour{
    
    public Transform player;
    public Vector2 smoothness;
    public Vector2 MaxBorder;
    public Vector2 MinBorder;

    private Vector2 speed;

    void Start(){
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    void FixedUpdate(){
        if (player != null){
            float positionX =  Mathf.SmoothDamp(transform.position.x, player.position.x, ref speed.x, smoothness.x);    
            float positionY =  Mathf.SmoothDamp(transform.position.y, player.position.y, ref speed.y, smoothness.y);

            transform.position = new Vector3(
                Mathf.Clamp(positionX, MinBorder.x, MaxBorder.x),
                Mathf.Clamp(positionY, MinBorder.y, MaxBorder.y),
                transform.position.z);
        }
    }
}
