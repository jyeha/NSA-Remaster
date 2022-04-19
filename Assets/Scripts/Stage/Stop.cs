using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stop : MonoBehaviour
{
    GameObject DeckInfoObj;
    GameObject StageInfoObj;

    public void stopStage(){
        DeckInfoObj = GameObject.Find("DeckInfo");
        StageInfoObj = GameObject.Find("StageInformation");

        Destroy(DeckInfoObj);
        Destroy(StageInfoObj);
        SceneManager.LoadScene("StageSelectScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
