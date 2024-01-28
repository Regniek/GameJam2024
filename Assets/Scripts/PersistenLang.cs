using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersistenLang : MonoBehaviour
{
    public Button ChangeLang;
    public TextMeshProUGUI PlayButtonText;
    public TextMeshProUGUI ChangeLangText;
    public TextMeshProUGUI Lang; 

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
        ChangeLangInterface();
    }

    void ChangeLangInterface()
    {
        if (Lang.text == "English")
        {
            PlayButtonText.text = "Play";
            ChangeLangText.text = "Change";
        }else
        {
            PlayButtonText.text = "Jugar";
            ChangeLangText.text = "Cambiar";
        }
    }
}
