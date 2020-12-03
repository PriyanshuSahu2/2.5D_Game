using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] AudioSource[] audio;
    [SerializeField] GameObject lines;

    void Start()
    {
        if(PlayerPrefs.GetString("EasyMode")=="On")
        {
            lines.SetActive(true);
        }
        else
        {
            lines.SetActive(false);
        }
        for(int i =0; i < audio.Length;i++)
        {
            if (PlayerPrefs.GetString("Sound") == "Play")
            {
                audio[i].Play();
            }
            else
                audio[i].Stop();

            float audioVolume = PlayerPrefs.GetFloat("Volume");
            audio[i].volume = audioVolume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
