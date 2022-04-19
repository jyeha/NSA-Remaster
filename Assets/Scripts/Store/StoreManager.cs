using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreManager : MonoBehaviour
{
    public Button back;
    public Button home;
    public Text goldText;
    public Text crystalText;

    GameObject gameManager;
    private UserClass userdata;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        back.onClick.AddListener(gameManager.GetComponent<GameManager>().GotoHome);
        home.onClick.AddListener(gameManager.GetComponent<GameManager>().GotoHome);
        userdata = gameManager.GetComponent<GameManager>().UserData;
        UISet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UISet(){
        goldText.text = userdata.gold.ToString();
        crystalText.text = userdata.crystal.ToString();
    }
}
