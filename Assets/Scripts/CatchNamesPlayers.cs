using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class CatchNamesPlayers : MonoBehaviour
{
    public TMP_InputField player1Input;
    public TMP_InputField player2Input;
    public TMP_InputField player3Input;
    public TMP_InputField player4Input;

    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();

        
        if (animator != null)
        {
            animator.Play("Idle-CHW1");
        }
    }

    public void GetInputValuesAndChangeScene()
    {
        string player1Value = player1Input.text;
        string player2Value = player2Input.text;
        string player3Value = player3Input.text;
        string player4Value = player4Input.text;

        // Puedes hacer algo con los valores (almacenarlos, enviarlos, etc.)
        // Por ejemplo, almacenarlos en PlayerPrefs para acceder en la nueva escena
        PlayerPrefs.SetString("Player1Value", player1Value);
        PlayerPrefs.SetString("Player2Value", player2Value);
        PlayerPrefs.SetString("Player3Value", player3Value);
        PlayerPrefs.SetString("Player4Value", player4Value);

        // Cambiar a la otra escena
        CambiarEscena();
    }

    private void CambiarEscena()
    {
        // Cambiar a la otra escena
        SceneManager.LoadScene(2);
        GameObject.FindGameObjectWithTag("Music").GetComponent<KeepAudio>().StopMusic();
    }
}
