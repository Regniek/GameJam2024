using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReadSpeaker;

public class TextReader : MonoBehaviour
{
    public TTSSpeaker speaker;
    public Selectable initiallySelectable;
    public float delay;

    void Start()
    {
        TTS.Init();
        ReadCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            TTS.InterruptAll();
            StopAllCoroutines();
            ReadCanvas();
        }
    }
    void ReadCanvas()
    {
        StartCoroutine(CanvasReaderCoroutine());
    }

    void ReadSelectable(Selectable selectable)
    {
        if (selectable is Button)
        {
            TTS.Say("Que hace un pato que se llama cuando se sienta? se va...", speaker);
        }
    }

    IEnumerator CanvasReaderCoroutine()
    {
        Selectable selectableToRead = initiallySelectable;
        while (selectableToRead != null)
        {
            ReadSelectable(selectableToRead);
            selectableToRead.Select();
            yield return new WaitUntil(() => speaker.audioSource.isPlaying);
            yield return new WaitForSeconds(delay);

            if (selectableToRead.navigation.selectOnRight != null)
            {
                selectableToRead = selectableToRead.navigation.selectOnRight;
            }
            else if (selectableToRead.navigation.selectOnDown != null)
            {
                selectableToRead = selectableToRead.navigation.selectOnDown;
            }
            else
            {
                selectableToRead = null;
            }
        }
    }
}
