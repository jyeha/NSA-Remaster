using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquadsManager : MonoBehaviour
{
    public Button back;
    public Button menu;
    public Button left;
    public Button right;

    public Button Team1Btn;
    public Button Team2Btn;
    public Button Team3Btn;
    public Button Team4Btn;

    public List<GameObject> Teams;
    // public GameObject Team1;
    // public GameObject Team2;
    // public GameObject Team3;
    // public GameObject Team4;

    GameObject gamemanager;
    List<DeckClass> deck;
    int current;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        deck = gamemanager.GetComponent<GameManager>().UserData.deck_list;

        back.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoHome);
        Team1Btn.onClick.AddListener(ShowTeam1);
        Team2Btn.onClick.AddListener(ShowTeam2);
        Team3Btn.onClick.AddListener(ShowTeam3);
        Team4Btn.onClick.AddListener(ShowTeam4);

        left.onClick.AddListener(ShowLeftTeam);
        right.onClick.AddListener(ShowRightTeam);
        
        DeckSetting();
        ShowTeam1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeckSetting(){
        for(int i=0;i<deck.Count;i++){
            DeckClass temp = deck[i];
            for(int j=0;j<deck[i].deck_member.Count;j++){
                int num = j+1;
                string objectname = "Operator"+ num.ToString();
                OperatorClass op = temp.deck_member[j];
                if(op==null)    continue;
                Debug.Log("deck "+ i + " operator " + num + "op_code " + op.op_code);
                GameObject member = Teams[i].transform.Find(objectname).gameObject;
                Image op_img = member.transform.Find("Image").gameObject.GetComponent<Image>();
                Text NameText = member.transform.Find("NameText").gameObject.GetComponent<Text>();
                Text LevelText = member.transform.Find("LevelText").gameObject.GetComponent<Text>();
                Text RareText = member.transform.Find("RareText").gameObject.GetComponent<Text>();

                op_img.sprite = Resources.Load<Sprite>("Images/Characters/" + op.img_name);
                NameText.text = op.name;
                LevelText.text = "Lv. "+op.level;
                RareText.text = op.rare;

            }

        }
    }

    void ShowLeftTeam(){
        if(current==1){
            ShowTeam4();
        }
        else if(current==2){
            ShowTeam1();
        }
        else if(current==3){
            ShowTeam2();
        }
        else if(current==4){
            ShowTeam3();
        }
    }

        void ShowRightTeam(){
        if(current==1){
            ShowTeam2();
        }
        else if(current==2){
            ShowTeam3();
        }
        else if(current==3){
            ShowTeam4();
        }
        else if(current==4){
            ShowTeam1();
        }
    }

    void ShowTeam1(){
        Teams[0].SetActive(true);
        Teams[1].SetActive(false);
        Teams[2].SetActive(false);
        Teams[3].SetActive(false);
        current = 1;
    }

    void ShowTeam2(){
        Teams[0].SetActive(false);
        Teams[1].SetActive(true);
        Teams[2].SetActive(false);
        Teams[3].SetActive(false);
        current = 2;
    }

    void ShowTeam3(){
        Teams[0].SetActive(false);
        Teams[1].SetActive(false);
        Teams[2].SetActive(true);
        Teams[3].SetActive(false);
        current = 3;
    }

    void ShowTeam4(){
        Teams[0].SetActive(false);
        Teams[1].SetActive(false);
        Teams[2].SetActive(false);
        Teams[3].SetActive(true);
        current = 4;
    }

}
