using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundIndicator : MonoBehaviour
{
    public float velocidadAnimacion = 0.2f;
    public Color colorNaranja;
    public Color colorRojo;
    public AudioLoudnessDetection detector;
    public float loudnessSensibility = 100;
    public float threshold = 1;

    private RectTransform contenedor;
    private RectTransform indicador;

    void Start()
    {
        contenedor = transform.GetComponent<RectTransform>();
        indicador = contenedor.GetChild(0).GetComponent<RectTransform>();   
    }

    void Update()
    {
        if (contenedor == null) return;
        if (indicador == null) return;
        
        float volumenActual = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        float nuevaAltura = Mathf.Lerp(indicador.sizeDelta.y, volumenActual * contenedor.sizeDelta.y, Time.deltaTime * velocidadAnimacion);
        Debug.Log("Altura" + nuevaAltura);
        Debug.Log("threshold" + threshold);

        indicador.sizeDelta = new Vector2(indicador.sizeDelta.x, nuevaAltura);


        if (volumenActual > 1.3)
        {
            Debug.Log("volumenActual" + volumenActual);
            AccionCuandoSonidoFuerte();
        }
    }

    void AccionCuandoSonidoFuerte()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        detector.StopMicrophone();
    }
}