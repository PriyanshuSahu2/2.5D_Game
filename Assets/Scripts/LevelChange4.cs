using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange4 : MonoBehaviour
{
    [SerializeField] GameObject finsh;
    [SerializeField] AudioSource audio;
    private void Start()
    {
        finsh.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        finsh.SetActive(true);
        audio.Play();
    }
}
