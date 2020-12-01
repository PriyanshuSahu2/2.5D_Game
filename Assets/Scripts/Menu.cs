using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject Continue;
    private void Start()
    {
       if( PlayerPrefs.GetInt("Once") == 1)
        {
            Continue.SetActive(true);
        }
    }
    public void PlayBtn()
    {
        PlayerPrefs.SetInt("Once", 1);
        PlayerPrefs.SetFloat("xPosition", 0);
        PlayerPrefs.SetFloat("yPosition", 0);
        SceneManager.LoadSceneAsync(1);
        
    }
    public void ContinueBtn()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
