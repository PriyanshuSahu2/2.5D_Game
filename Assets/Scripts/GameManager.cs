using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] cam;
    [SerializeField] GameObject player;
    public float yPos;
    [SerializeField] float[] yTriggerCam;
    private void Update()
    {
        if (player == null) return;
        yPos = player.transform.position.y;
        if (yPos == null) return;
        if(yPos <=yTriggerCam[0] )
        {
            Debug.Log("true");
            
            cam[6].SetActive(false);
            cam[7].SetActive(false);
            cam[1].SetActive(false);
            cam[2].SetActive(false);
            cam[3].SetActive(false);
            cam[4].SetActive(false);
            cam[5].SetActive(false);
            cam[0].SetActive(true);
        }
        else if(yPos >= yTriggerCam[0] && yPos <= yTriggerCam[1])
        {
            Debug.Log("true1");
            cam[6].SetActive(false);
            cam[7].SetActive(false);
            cam[1].SetActive(true);
            cam[2].SetActive(false);
            cam[3].SetActive(false);
            cam[4].SetActive(false);
            cam[5].SetActive(false);
            cam[0].SetActive(false);
        }
        else if (yPos >= yTriggerCam[1] && yPos <= yTriggerCam[2])
        {
            cam[6].SetActive(false);
            cam[7].SetActive(false);
            cam[1].SetActive(false);
            cam[2].SetActive(true);
            cam[3].SetActive(false);
            cam[4].SetActive(false);
            cam[5].SetActive(false);
            cam[0].SetActive(false);
        }
        else if (yPos >= yTriggerCam[2] && yPos <= yTriggerCam[3])
        {
            cam[6].SetActive(false);
            cam[7].SetActive(false);
            cam[1].SetActive(false);
            cam[2].SetActive(false);
            cam[3].SetActive(true);
            cam[4].SetActive(false);
            cam[5].SetActive(false);
            cam[0].SetActive(false);
        }
        else if (yPos >= yTriggerCam[3] && yPos <= yTriggerCam[4])
        {
            cam[6].SetActive(false);
            cam[7].SetActive(false);
            cam[1].SetActive(false);
            cam[2].SetActive(false);
            cam[3].SetActive(false);
            cam[4].SetActive(true);
            cam[5].SetActive(false);
            cam[0].SetActive(false);
        }
        else if (yPos >= yTriggerCam[4] && yPos <= yTriggerCam[5])
        {
            cam[6].SetActive(false);
            cam[7].SetActive(false);
            cam[1].SetActive(false);
            cam[2].SetActive(false);
            cam[3].SetActive(false);
            cam[4].SetActive(false);
            cam[5].SetActive(true);
            cam[0].SetActive(false);
        }
        else if (yPos >= yTriggerCam[5] && yPos <= yTriggerCam[6])
        {
            cam[6].SetActive(true);
            cam[7].SetActive(false);
            cam[1].SetActive(false);
            cam[2].SetActive(false);
            cam[3].SetActive(false);
            cam[4].SetActive(false);
            cam[5].SetActive(false);
            cam[0].SetActive(false);
        }
    }


}