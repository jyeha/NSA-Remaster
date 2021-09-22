using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public Button map;
    public Button squads;
    public Button operators;
    public Button gacha;
    public Button shop;
    public Button banner;
    public Image assistant_image;
    GameObject gamemanager;

    //public OwnOperatorList OpList;



    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        squads.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoSquad);
        operators.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoOperator);
        gacha.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoGacha);
        

        SetAssistant(gamemanager.GetComponent<GameManager>().UserData.assistant);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetAssistant(OperatorClass assis){
        assistant_image.sprite = Resources.Load<Sprite>("Images/Characters/" + assis.img_name);
    }
}
