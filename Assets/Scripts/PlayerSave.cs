using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSave : MonoBehaviour
{
    #region -- Variable--
    public GameObject player;
    public float xPos;
    public float yPos;
    public static PlayerSave PS;
    #endregion
    void Start()
    {

    }
    private void Awake()
    {
        xPos = PlayerPrefs.GetFloat("xPosition");
        yPos = PlayerPrefs.GetFloat("yPosition");
        player.transform.position = new Vector2(xPos, yPos);
    }
    // Update is called once per frame
    void Update()
    {

        Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        int index = scene.buildIndex;
        Debug.Log(PlayerPrefs.GetInt("Level"));
        PlayerPrefs.SetInt("Level", index);
        xPos = player.transform.position.x;
        yPos = player.transform.position.y;
        PlayerPrefs.SetFloat("xPosition", xPos);
        PlayerPrefs.SetFloat("yPosition", yPos);

    }
}
