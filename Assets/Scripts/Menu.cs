using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    [SerializeField] GameObject Continue;
    [SerializeField] GameObject optionWindow;
    [SerializeField] AudioSource audio;
    [SerializeField] Slider volumeSlider;
    [SerializeField] GameObject backBtn;
    private void Start()
    {
        volumeSlider.value = audio.volume;
       if( PlayerPrefs.GetInt("Once") == 1)
        {
            Continue.SetActive(true);
        }
        
    }
    public void PlayBtn()
    {
        PlayerPrefs.SetInt("Once", 1);
        PlayerPrefs.SetFloat("xPosition", 0);
        PlayerPrefs.SetFloat("yPosition", 1);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
        
    }
    public void ContinueBtn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("Level"));
    }
    public void OptionBtn()
    {
        optionWindow.SetActive(true);
        
    }
    public void SoundOn()
    {
        PlayerPrefs.SetString("Sound", "Play");
        Debug.Log("True");
        audio.Play();
    }
    public void SoundOff()
    {
        PlayerPrefs.SetString("Sound", "Stop");
        Debug.Log("false");
        audio.Stop();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionWindow.activeSelf)
            {
                optionWindow.SetActive(false);
            }
        }
        Debug.Log(PlayerPrefs.GetInt("Level"));


    }
    public void SoundOntoggle(bool newvalue)
    {
        if(newvalue)
        {
            SoundOn();
        }
        else
        {
            SoundOff();
        }

    }
    public void EasyOntoggle(bool newvalue)
    {
        if (newvalue)
        {
            PlayerPrefs.SetString("EasyMode", "On");
        }
        else
        {
            PlayerPrefs.SetString("EasyMode", "Off");
        }

    }
    public void sliderChanger(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
    }
    public void Backbtn()
    {
        backBtn.SetActive(false);
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
  
}
