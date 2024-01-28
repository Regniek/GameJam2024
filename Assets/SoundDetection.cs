using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundDetection : MonoBehaviour
{
    public float threshold = 0.3f;
    public int sampleWindow = 64;
    public float loudnessSensibility = 100;
    public AudioLoudnessDetection detector;
    public GameObject elementoPrefab;
    private Canvas canvas;

    void Update()
    {
        float volumenActual = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (volumenActual > threshold)
        {
            AccionCuandoSonidoFuerte();
        }
    }

    void AccionCuandoSonidoFuerte()
    {
        SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
        detector.StopMicrophone();
    }
}
