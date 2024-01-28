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
    public Button GenerateJokes; // Asigna el botón en el Inspector
    public TextMeshProUGUI DialogText; // Asigna el TextMesh en el Inspector
    public TTSSpeaker speaker;
    public float delay;

    private string apiKey = System.Environment.GetEnvironmentVariable("API_KEY");
    private string apiUrl = System.Environment.GetEnvironmentVariable("API_URL");
    


    void Start()
    {
        LoadConfigurations();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(CallApi);
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
        Debug.Log("I call api");
        StartCoroutine("MakeApiRequest");
        
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
            yield return new WaitUntil(() => speaker.audioSource.isPlaying);
            yield return new WaitForSeconds(delay);
        }
    }
}
