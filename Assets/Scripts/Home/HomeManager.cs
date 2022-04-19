using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public Button map;
    public Button squads;
    public Button operators;
    public Button gacha;
    public Button shop;
    public Button banner;
    public Image assistant_image;
    public Text gold_text;
    public Text crystal_text;
    GameObject gamemanager;


    //public OwnOperatorList OpList;



    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        squads.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoSquad);
        operators.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoOperator);
        gacha.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoGacha);
        map.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoStageSelect);
        banner.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoGacha);
        shop.onClick.AddListener(MovetoShop);

        SetAssistant(gamemanager.GetComponent<GameManager>().UserData.assistant);
        SetMoney(gamemanager.GetComponent<GameManager>().UserData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovetoShop(){
        SceneManager.LoadScene("StoreScene");
    }
    void SetAssistant(OperatorClass assis){
        assistant_image.sprite = Resources.Load<Sprite>("Images/Characters/" + assis.img_name);
    }

    void SetMoney(UserClass user){
        int gold = user.gold;
        int crystal = user.crystal;

        gold_text.text = gold.ToString();
        crystal_text.text = crystal.ToString();
    }
}
