using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelPause : MonoBehaviour
{
    public bool isPause = false;

    public void pause(){
        if(!isPause){
            Time.timeScale = 0;
            isPause = true;

        }
    }
}
