using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;
using System.IO;
using ReadSpeaker;
using System;

public class GenerateJokesScript : MonoBehaviour
{
    public Button GenerateJokes; // Asigna el botón en el Inspector
    public TextMeshProUGUI DialogText; // Asigna el TextMesh en el Inspector
    public TextMeshProUGUI score;
    public TTSSpeaker speaker;
    public float delay;
    public bool repeat = false ;
    public AudioLoudnessDetection detector;
    public int scoreInNumber = 0 ;
    public string lang;
    public string category = "/general";
    public string type = "/challenge";
    public string endpoint = "/random";

    private string apiKey = System.Environment.GetEnvironmentVariable("API_KEY");
    private string apiUrl = System.Environment.GetEnvironmentVariable("API_URL");
    


    void Start()
    {
        lang = PlayerPrefs.GetString("lang");
        LoadConfigurations();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(initializeGame);

    }

    void LoadConfigurations()
    {
        TextAsset targetFile = Resources.Load<TextAsset>("config");
        string json = targetFile.text;
        JSONNode configData = JSON.Parse(json);
        apiKey = configData["API_KEY"];
        apiUrl = configData["API_URL"];
    }
    void CallApi()
    {
        StartCoroutine("MakeApiRequest");
    }

    void initializeGame()
    {
        repeat = true;
        CallApi();
        OcultarBoton();
    }

    public void OcultarBoton()
    {
        Button btn = GetComponent<Button>();
        btn.transform.localScale = Vector3.zero;
    }

    public void MostrarBoton()
    {
        Button btn = GetComponent<Button>();
        btn.transform.localScale = Vector3.one;
    }

    IEnumerator MakeApiRequest()
    {
        string url = apiUrl + category +"/"+ lang + type + endpoint;
        Debug.Log(url);
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("X-API-KEY", apiKey);
  

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al realizar la solicitud: " + request.error);
        }
        else
        {
            JSONNode data = JSON.Parse(request.downloadHandler.text);
            Debug.Log(data["data"]["description"]);
            DialogText.text = data["data"]["description"];
            TTS.Say(data["data"]["description"], speaker);
            if (repeat == true )
            {
                StartCoroutine(EsperarYContinuar());
            }
            yield return new WaitUntil(() => speaker.audioSource.isPlaying);
            yield return new WaitForSeconds(delay);
            detector.MicriphoneToAudioClip();
        }
    }

    private IEnumerator EsperarYContinuar()
    {
        Debug.Log("Inicio de la espera");
      
        yield return new WaitForSeconds(20f);
        detector.StopMicrophone();
        yield return new WaitForSeconds(20f);
        scoreInNumber++;
        score.text = scoreInNumber.ToString();
        CallApi();
    }
}
