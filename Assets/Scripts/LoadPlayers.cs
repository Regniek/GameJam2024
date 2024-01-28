using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadPlayers : MonoBehaviour
{
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public TextMeshProUGUI player3Text;
    public TextMeshProUGUI player4Text;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI DialogText;
    public TextMeshProUGUI PlayButtonText;

    void Start()
    {
        // Obtener los valores guardados en PlayerPrefs
        string player1Value = PlayerPrefs.GetString("Player1Value", "");
        string player2Value = PlayerPrefs.GetString("Player2Value", "");
        string player3Value = PlayerPrefs.GetString("Player3Value", "");
        string player4Value = PlayerPrefs.GetString("Player4Value", "");

        // Asignar los valores a los objetos TextMeshPro
        player1Text.text = player1Value;
        player2Text.text = player2Value;
        player3Text.text = player3Value;
        player4Text.text = player4Value;
        UpdateLangInterface();

    }
    void UpdateLangInterface()
    {
        string lang = PlayerPrefs.GetString("lang");
        if (lang == "es")
        {
            ScoreText.text = "Puntaje";
            DialogText.text = "Prepárense...\n\nEl objetivo es cumplir el reto sin reírse";
            PlayButtonText.text = "EMPIEZA EL RETO";
        }
        else
        {
            ScoreText.text = "Score";
            DialogText.text = "Get ready...\n\nThe goal is to complete the challenge without laughing";
            PlayButtonText.text = "START CHALLENGE";
        }
    }
}
