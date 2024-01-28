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
    }
}
