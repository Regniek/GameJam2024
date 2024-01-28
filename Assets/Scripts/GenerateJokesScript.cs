using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;
using System.IO;
using ReadSpeaker;

public class GenerateJokesScript : MonoBehaviour
{
    public Button GenerateJokes; // Asigna el bot�n en el Inspector
    public TextMeshProUGUI DialogText; // Asigna el TextMesh en el Inspector
    public TTSSpeaker speaker;
    public float delay;
    public bool repeat = false ;

    private string apiKey = System.Environment.GetEnvironmentVariable("API_KEY");
    private string apiUrl = System.Environment.GetEnvironmentVariable("API_URL");
    


    void Start()
    {
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
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        request.SetRequestHeader("X-API-KEY", apiKey);
  

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al realizar la solicitud: " + request.error);
        }
        else
        {
            Debug.Log("request:" + request.downloadHandler.text);
            JSONNode data = JSON.Parse(request.downloadHandler.text);
            Debug.Log("data:" + data);


            DialogText.text = data["data"]["description"];
            TTS.Say(data["data"]["description"], speaker);
            if (repeat == true )
            {
                StartCoroutine(EsperarYContinuar());
            }
            yield return new WaitUntil(() => speaker.audioSource.isPlaying);
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator EsperarYContinuar()
    {
        Debug.Log("Inicio de la espera");

        yield return new WaitForSeconds(20f);
        CallApi();
        Debug.Log("Despu�s de esperar 20 segundos, contin�a aqu�");
    }
}
