using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersistenLang : MonoBehaviour
{
    public Button ChangeLang; // Asigna el botón en el Inspector
    public TextMeshProUGUI Lang; // Asigna el TextMesh en el Inspector

    public string lang = "en";
    public string langText = "English";
    void Start()
    {
        PlayerPrefs.SetString("lang", lang);
        ChangeLang.onClick.AddListener(SetUpLang);

    }
    void SetUpLang()
    {
        if(Lang.text == "English") {
            lang = "es";
            langText = "Español";
            Lang.text = langText;
            PlayerPrefs.SetString("lang", lang);
        }
        else
        {
            lang = "en";
            langText = "English";
            Lang.text = langText;
            PlayerPrefs.SetString("lang", lang);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
