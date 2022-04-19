using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public Button back;
    public Button menu;

    public Button Stage01Button;

    GameObject gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        back.onClick.AddListener(GoBack);
        menu.onClick.AddListener(GoHome);
        Stage01Button.onClick.AddListener(WhichStage);
    }

    void GoBack(){
        GameObject stageInfoObject = GameObject.Find("StageInfo");
        if(stageInfoObject != null){
            Destroy(stageInfoObject);
        }
        SceneManager.LoadScene("HomeScene");
    }

    void GoHome(){
        GameObject stageInfoObject = GameObject.Find("StageInfo");
        if(stageInfoObject != null){
            Destroy(stageInfoObject);
        }
        SceneManager.LoadScene("HomeScene");
    }

    void WhichStage(){
        GameObject currentClicked = EventSystem.current.currentSelectedGameObject;

        if(currentClicked.name == "Stage01"){
            GameObject stageSaveObject = new GameObject("StageInfo");
            stageSaveObject.AddComponent<StageInfoSave>();
            stageSaveObject.GetComponent<StageInfoSave>().StageNum = 1;
        }

        SceneManager.LoadScene("SquadBeforeStage");
    }
}
