using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayersNamesManager : MonoBehaviour
{
    public TMP_InputField player1Input;
    public TMP_InputField player2Input;
    public TMP_InputField player3Input;
    public TMP_InputField player4Input;
    public TextMeshProUGUI PlayButtonText;
    public TextMeshProUGUI PlayerOneText;
    public TextMeshProUGUI PlayerTwoText;
    public TextMeshProUGUI PlayerThreeText;
    public TextMeshProUGUI PlayerFourText;
    // Start is called before the first frame update
    void Start()
    {
        // Obtener los valores guardados en PlayerPrefs
        string player1Value = PlayerPrefs.GetString("Player1Value", "");
        string player2Value = PlayerPrefs.GetString("Player2Value", "");
        string player3Value = PlayerPrefs.GetString("Player3Value", "");
        string player4Value = PlayerPrefs.GetString("Player4Value", "");

        // Asignar los valores a los objetos TextMeshPro
        player1Input.text = player1Value;
        player2Input.text = player2Value;
        player3Input.text = player3Value;
        player4Input.text = player4Value;

        UpdateLangInterface();
    }
    void UpdateLangInterface()
    {
        string lang = PlayerPrefs.GetString("lang");
        if (lang == "es")
        {
            PlayButtonText.text = "Jugar";
            PlayerOneText.text = "Nombre del Jugador ...";
            PlayerTwoText.text = "Nombre del Jugador ...";
            PlayerThreeText.text = "Nombre del Jugador ...";
            PlayerFourText.text = "Nombre del Jugador ...";
}
        else
        {
            PlayButtonText.text = "Play";
            PlayerOneText.text = "Player name ...";
            PlayerTwoText.text = "Player name ...";
            PlayerThreeText.text = "Player name ...";
            PlayerFourText.text = "Player name ...";
        }
    }

}
