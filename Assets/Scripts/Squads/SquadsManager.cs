using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


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

    public List<Button> Operator_Choose_Buttons;
    public List<GameObject> Teams;

    public GameObject op_;
    public GameObject parent_panel;
    public GameObject popup_panel;
    public Button popup_back;
    public Button popup_confirm;

    public OperatorClass selected_info;

    public GameObject info_panel;
    public GameObject contextPanel;

    GameObject chosen_squad;
    GameObject gamemanager;
    List<DeckClass> deck;
    List<OperatorClass> OpList;
    public int current;
    int current_block_num;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        deck = gamemanager.GetComponent<GameManager>().UserData.deck_list;
        OpList = gamemanager.GetComponent<GameManager>().UserData.own_op_list;


        back.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoHome);
        Team1Btn.onClick.AddListener(ShowTeam1);
        Team2Btn.onClick.AddListener(ShowTeam2);
        Team3Btn.onClick.AddListener(ShowTeam3);
        Team4Btn.onClick.AddListener(ShowTeam4);

        left.onClick.AddListener(ShowLeftTeam);
        right.onClick.AddListener(ShowRightTeam);

        for(int i=0;i<16;i++)
            Operator_Choose_Buttons[i].onClick.AddListener(OpenPopup);

        popup_back.onClick.AddListener(ClosePopup);
        popup_confirm.onClick.AddListener(PutinSquads);
        DeckSetting();
        ShowTeam1();
        ClosePopup();
    }

    void DeckSetting(){
        for(int i=0;i<deck.Count;i++){
            DeckClass temp = deck[i];
            for(int j=0;j<deck[i].deck_member.Count;j++){
                int num = j+1;
                string objectname = "Operator"+ num.ToString();
                OperatorClass op = temp.deck_member[j];
                if(op==null)    continue;
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
        Team1Btn.GetComponent<Image>().color = new Color(150/255f, 150/255f, 150/255f);
        Team2Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        Team3Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        Team4Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        current = 1;
    }

    void ShowTeam2(){
        Teams[0].SetActive(false);
        Teams[1].SetActive(true);
        Teams[2].SetActive(false);
        Teams[3].SetActive(false);
        Team2Btn.GetComponent<Image>().color = new Color(150/255f, 150/255f, 150/255f);
        Team1Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        Team3Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        Team4Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        current = 2;
    }

    void ShowTeam3(){
        Teams[0].SetActive(false);
        Teams[1].SetActive(false);
        Teams[2].SetActive(true);
        Teams[3].SetActive(false);

        Team3Btn.GetComponent<Image>().color = new Color(150/255f, 150/255f, 150/255f);
        Team1Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        Team2Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        Team4Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        current = 3;
    }

    void ShowTeam4(){
        Teams[0].SetActive(false);
        Teams[1].SetActive(false);
        Teams[2].SetActive(false);
        Teams[3].SetActive(true);
        Team4Btn.GetComponent<Image>().color = new Color(150/255f, 150/255f, 150/255f);
        Team1Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        Team2Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        Team3Btn.GetComponent<Image>().color = new Color(1, 1, 1);
        current = 4;
    }

    void OpenPopup(){
        popup_panel.SetActive(true);

        Transform[] childList  = parent_panel.GetComponentsInChildren<Transform>();
        if(childList != null){
            for(int i=0;i<childList.Length;i++){
                if(childList[i] != parent_panel.transform){
                    Destroy(childList[i].gameObject);
                }
            }
        }

        chosen_squad = EventSystem.current.currentSelectedGameObject;
        if(chosen_squad.name == "Operator1"){
            current_block_num = 0;
        }
        else if(chosen_squad.name == "Operator2"){
            current_block_num = 1;
        }
        else if(chosen_squad.name == "Operator3"){
            current_block_num = 2;
        }
        else{
            current_block_num = 3;
        }

        for(int i=0;i<OpList.Count;i++){
            OperatorClass op = OpList[i];
            bool isinDeck = false;            

            for(int j=0;j<deck[current-1].deck_member.Count;j++){
                if(op.op_code == deck[current-1].deck_member[j].op_code){
                    isinDeck = true;
                }
            }
            if(!isinDeck)
                CreateOperators(op);
        }
    }

    void ClosePopup(){
        ShowChosenReset();
        popup_panel.SetActive(false);
    }

    public void CreateOperators(OperatorClass op){
        GameObject btn = (GameObject)Instantiate(op_);
        btn.transform.SetParent(parent_panel.transform);

        btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Characters/" + op.img_name);
        btn.name = op.op_code.ToString();

        // text
        GameObject tmppanel = btn.transform.Find("Panel").gameObject;
        GameObject rareText = btn.transform.Find("rareText").gameObject;
        GameObject nameText = tmppanel.transform.Find("NameText").gameObject;
        GameObject levelText = tmppanel.transform.Find("LevelText").gameObject;
        Text nametxt = nameText.GetComponent<Text>();
        Text leveltxt = levelText.GetComponent<Text>();
        Text raretxt = rareText.GetComponent<Text>();
        nametxt.text = op.name;
        leveltxt.text = "Lv. " + op.level;
        raretxt.text = op.rare;

        btn.GetComponent<SaveforBtn>().oper_info.SetProperty(op);
        btn.GetComponent<Button>().onClick.AddListener(ShowChosenOperators);
    }

    public void ShowChosenOperators(){
        GameObject clicked = EventSystem.current.currentSelectedGameObject;
        selected_info = clicked.GetComponent<SaveforBtn>().oper_info;

        // show on right screen
        info_panel.transform.Find("Image").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Characters/" + selected_info.img_name);
        info_panel.transform.Find("NameText").gameObject.GetComponent<Text>().text = selected_info.name;
        info_panel.transform.Find("RareText").gameObject.GetComponent<Text>().text = selected_info.rare;
        info_panel.transform.Find("LevelText").gameObject.GetComponent<Text>().text = "Lv. " + selected_info.level.ToString();
        info_panel.transform.Find("AttackText").gameObject.GetComponent<Text>().text = selected_info.attack.ToString();
        info_panel.transform.Find("CostText").gameObject.GetComponent<Text>().text = selected_info.cost.ToString();
    }

    public void ShowChosenReset(){
        info_panel.transform.Find("Image").gameObject.GetComponent<Image>().sprite = null;
        info_panel.transform.Find("NameText").gameObject.GetComponent<Text>().text = "";
        info_panel.transform.Find("RareText").gameObject.GetComponent<Text>().text = "";
        info_panel.transform.Find("LevelText").gameObject.GetComponent<Text>().text = "";
        info_panel.transform.Find("AttackText").gameObject.GetComponent<Text>().text = "";
        info_panel.transform.Find("CostText").gameObject.GetComponent<Text>().text = "";
    }

    public void PutinSquads(){
        if(deck[current-1].deck_member.Count > 0){
            if(current_block_num < deck[current-1].deck_member.Count && deck[current-1].deck_member[current_block_num] != null){
                deck[current-1].deck_member.RemoveAt(current_block_num);
            }
        }
        if(deck[current-1].deck_member.Count < 3){
            deck[current-1].deck_member.Add(selected_info);
        }
        else
            deck[current-1].deck_member.Insert(current_block_num, selected_info);

        UserClass userInfo = gamemanager.GetComponent<GameManager>().UserData; 

        string userJsonStr = gamemanager.GetComponent<GameManager>().ObjectToJson(userInfo);
        gamemanager.GetComponent<GameManager>().CreatetoJsonFile(Application.streamingAssetsPath, "Data/UserData", userJsonStr);

        DeckSetting();
        ClosePopup();

    }
}
