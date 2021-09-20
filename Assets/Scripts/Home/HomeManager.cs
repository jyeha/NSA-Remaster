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
    GameObject gamemanager;

    //public OwnOperatorList OpList;



    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        squads.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoSquad);
        operators.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoOperator);
        gacha.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoGacha);
        //OpList = gamemanager.GetComponent<GameManager>().LoadJsonFile<OwnOperatorList>(Application.dataPath,"Scripts/Data/operatorlist");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
