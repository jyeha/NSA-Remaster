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
    public GameObject toastPanel;
    public Text toastText;

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
            ShowToastMessage();
            return;
        }

        if(StageInfo.GetComponent<StageInfoSave>().StageNum == 1){
            SceneManager.LoadScene("Stage1Scene");
        }
    }

    public void ShowToastMessage(){
        toastPanel.SetActive(true);
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut(){
        toastText.text = "편성 인원이 부족합니다.";


        Color c = toastPanel.GetComponent<Image>().color;
        c.a = 0.7f;
        toastPanel.GetComponent<Image>().color = c;

        while(c.a >= 0.0f){
            c.a -= Time.deltaTime;
            toastPanel.GetComponent<Image>().color = c;
            yield return null;
        }
        
        toastPanel.SetActive(false);
    }
}
