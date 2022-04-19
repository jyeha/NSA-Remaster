using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StagePrepareManager : MonoBehaviour
{
    public Button StartButton;
    public Button backButton;
    public Button homeButton;
    
    [SerializeField]
    private ModifySquad modifySquad;

    GameObject gamemanager;
    GameObject StageInfo;
    List<DeckClass> deck;
    List<OperatorClass> OpList;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        StageInfo = GameObject.Find("StageInfo");

        deck = gamemanager.GetComponent<GameManager>().UserData.deck_list;
        OpList = gamemanager.GetComponent<GameManager>().UserData.own_op_list;

        backButton.onClick.AddListener(GoBack);
        homeButton.onClick.AddListener(GoHome);
        StartButton.onClick.AddListener(StartStage);
    }

    void GoBack(){
        GameObject deckInfoObject = GameObject.Find("DeckInfo");
        if(deckInfoObject != null){
            Destroy(deckInfoObject);
        }

        GameObject stageInfoObject = GameObject.Find("StageInfo");
        if(stageInfoObject != null){
            Destroy(stageInfoObject);
        }

        SceneManager.LoadScene("StageSelectScene");
    }

    void GoHome(){
        GameObject deckInfoObject = GameObject.Find("DeckInfo");
        if(deckInfoObject != null){
            Destroy(deckInfoObject);
        }

        GameObject stageInfoObject = GameObject.Find("StageInfo");
        if(stageInfoObject != null){
            Destroy(stageInfoObject);
        }
        
        SceneManager.LoadScene("HomeScene");
    }

    void StartStage(){

        GameObject deckSaveObject = new GameObject("DeckInfo");
        deckSaveObject.AddComponent<DeckInfo>();
        DeckInfo deckInfo = deckSaveObject.GetComponent<DeckInfo>();

        if(modifySquad.current == 1){
            deckInfo.SelectedDeckInfo = deck[0];
        }
        else if(modifySquad.current == 2){
            deckInfo.SelectedDeckInfo = deck[1];
        }
        else if(modifySquad.current == 3){
            deckInfo.SelectedDeckInfo = deck[2];
        }
        else if(modifySquad.current == 4){
            deckInfo.SelectedDeckInfo = deck[3];
        }

        if(deckInfo.SelectedDeckInfo.deck_member.Count < 1) {
            Debug.Log("편성 인원 수 부족!");
            return;
        }

        if(StageInfo.GetComponent<StageInfoSave>().StageNum == 1){
            SceneManager.LoadScene("Stage1Scene");
        }
    }
}
