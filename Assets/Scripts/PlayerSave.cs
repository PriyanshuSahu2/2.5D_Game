using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        xPos = PlayerPrefs.GetFloat("xPosition");
        yPos = PlayerPrefs.GetFloat("yPosition");
        player.transform.position = new Vector2(xPos, yPos);
    }

    // Update is called once per frame
    void Update()
    {
        xPos = player.transform.position.x;
        yPos = player.transform.position.y;
        PlayerPrefs.SetFloat("xPosition", xPos);
        PlayerPrefs.SetFloat("yPosition", yPos);

    }
}
