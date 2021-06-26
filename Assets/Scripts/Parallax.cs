using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] fundos;
    public float[] velocidadeParallax;
    public float suavidade;
    public Transform cameraJogo;

    private Vector3 visualizarCamera;
    
    void Start(){
        visualizarCamera = cameraJogo.position;
    }

    void FixedUpdate(){
        for (int i = 0; i < fundos.Length; i++){
            float parallax = (visualizarCamera.x - cameraJogo.position.x) * velocidadeParallax[i];
            float posicaoAlvoX = fundos[i].position.x - parallax;
            Vector3 posicao = new Vector3(posicaoAlvoX, fundos[i].position.y, fundos[i].position.z);
            fundos[i].position = Vector3.Lerp(fundos[i].position, posicao, suavidade * Time.deltaTime);
        }
        visualizarCamera = cameraJogo.position;
    }
}
