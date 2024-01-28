using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundDetection : MonoBehaviour
{
    public float threshold = 0.3f;
    public float loudnessSensibility = 100;
    public AudioLoudnessDetection detector;

    void Update()
    {
        float volumenActual = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (volumenActual > 1.2)
        {
            AccionCuandoSonidoFuerte();
        }
    }

    void AccionCuandoSonidoFuerte()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        detector.StopMicrophone();
    }
}
