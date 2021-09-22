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

    public GameObject Team1;
    public GameObject Team2;
    public GameObject Team3;
    public GameObject Team4;

    GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        back.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoHome);
        
        Team1.SetActive(true);
        Team2.SetActive(false);
        Team3.SetActive(false);
        Team4.SetActive(false);

        DeckSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeckSetting(){

    }
}
