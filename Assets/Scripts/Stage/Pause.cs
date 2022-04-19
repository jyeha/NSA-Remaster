using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public isPause ispause;
    public GameObject PausePanel;

    public void pause(){
        if(!ispause.isPaused){
            Time.timeScale = 0;
            ispause.isPaused = true;
            PausePanel.SetActive(true);
        }
    }

    public void cancel(){
        if(ispause.isPaused){
            Time.timeScale = 1;
            ispause.isPaused = false;
            PausePanel.SetActive(false);
        }
    }
}
