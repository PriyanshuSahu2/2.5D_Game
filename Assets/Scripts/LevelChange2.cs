using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange2 : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(3);
    }
}
