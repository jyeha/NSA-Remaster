using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetRewards : MonoBehaviour
{
    GameObject gameManager;
    GameObject stageInfoObject;
    GameObject deckInfoObject;

    public Text stageText;
    //public Text crystalText;
    public Text potionText;
    public Text goldText;
    public Image characterImage;
    public Image PerfectStar;

    [SerializeField]
    private item Item;
    [SerializeField]
    private StageInfo stageInfo;
    [SerializeField]
    private UserClass userInfo;
    [SerializeField]
    private DeckClass deckInfo;
    private bool showEnd = false;

    void Start(){
        gameManager = GameObject.Find("GameManager");
        stageInfoObject = GameObject.Find("StageInformation");
        deckInfoObject = GameObject.Find("DeckInfo");

        userInfo = gameManager.GetComponent<GameManager>().UserData;
        Item = gameManager.GetComponent<GameManager>().UserData.userItem;
        stageInfo = stageInfoObject.GetComponent<StageInfo>();
        deckInfo = deckInfoObject.GetComponent<DeckInfo>().SelectedDeckInfo;

        Destroy(stageInfoObject);
        Destroy(deckInfoObject);
        GetItems();
        ShowResults();
    }

    void Update(){
        if(showEnd && Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("StageSelectScene");
        }
    }

    void GetItems(){
        userInfo.exp += stageInfo.gainEXP;
        if(userInfo.exp > 1000){
            userInfo.level++;
            userInfo.exp -= 1000;
        }

        userInfo.gold += stageInfo.gainGold;
        Item.potion += stageInfo.gainPotion;

        if(stageInfo.isPerfectClear){
            userInfo.crystal += stageInfo.gainCrystal;
        }

        userInfo.map_clear = stageInfo.stageNum;
        
    }

    void ShowResults(){
        stageText.text = "스테이지 " + stageInfo.stageNum.ToString();
        potionText.text = stageInfo.gainPotion.ToString();
        goldText.text = stageInfo.gainGold.ToString();

        int i = Random.Range(0, deckInfo.deck_member.Count);
        OperatorClass op = deckInfo.deck_member[i];
        characterImage.sprite = Resources.Load<Sprite>("Images/Characters/" + op.img_name);

        if(stageInfo.isPerfectClear){
            PerfectStar.sprite = Resources.Load<Sprite>("Images/UI/Star");
        }
        else{
            PerfectStar.sprite = Resources.Load<Sprite>("Images/UI/GrayStar");
        }

        showEnd = true;
    }
}
