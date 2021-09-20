using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    public Button back;
    public Button menu;
    public Button oneTime;
    public Button tenTimes;

    GameObject gamemanager;


    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        back.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoHome);

        oneTime.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoGachaResult);
        tenTimes.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoGachaResult);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
