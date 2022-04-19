using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class AccountCreator : MonoBehaviour
{
    public InputField inputField;
    public Button inputButton, yesButton, noButton;
    public Text nameText;
    public GameObject PopupPanel;
    public string name;

    private UserClass user;
    private OperatorClass appleSR;

    GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        FindAppleSR(gamemanager.GetComponent<GameManager>().PullList.AllOperatorList);

        inputButton.onClick.AddListener(GetPlayerInput);
        yesButton.onClick.AddListener(ClickYes);
        noButton.onClick.AddListener(ClickNo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindAppleSR(List<OperatorClass> allOperator){
        for(int i=0;i<allOperator.Count;i++){
            if(allOperator[i].op_code == 1){
                appleSR = new OperatorClass();
                appleSR.SetProperty(allOperator[i]);
            }
        }
    }

    void SetEmptyDeck(List<DeckClass> deckList){
        for(int i=0;i<4;i++){
            DeckClass newDeck = new DeckClass();
            newDeck.deck_name = "팀 " + (i+1).ToString();
            newDeck.deck_member = new List<OperatorClass>();
            deckList.Add(newDeck);
        }   
    }

    void GetPlayerInput(){
        nameText.text = inputField.text;
        PopupPanel.SetActive(true);
    }

    void ClickYes(){
        // UserData 생성
        name = nameText.text.ToString();
        CreateNewUserData();
        LoadUserData();
        //SceneManager.LoadScene("HomeScene");
        SceneManager.LoadScene("PrologueScene");
    }

    void ClickNo(){
        PopupPanel.SetActive(false);
    }

    void CreateNewUserData(){
        user = new UserClass();

        user.initUser();

        user.ID = UnityEngine.Random.Range(10000000, 99999999);
        user.name = this.name;
        user.assistant = appleSR;
        user.own_op_list.Add(appleSR);
        
        SetEmptyDeck(user.deck_list);
        
        string userJsonStr = gamemanager.GetComponent<GameManager>().ObjectToJson(user);
        gamemanager.GetComponent<GameManager>().CreatetoJsonFile(Application.dataPath, "Scripts/Data/UserData", userJsonStr);
    }

    void LoadUserData(){
        UserClass tempUser;
        tempUser = gamemanager.GetComponent<GameManager>().LoadJsonFile<UserClass>(Application.dataPath,"Scripts/Data/UserData");
        gamemanager.GetComponent<GameManager>().UserData = tempUser;
    }
}
