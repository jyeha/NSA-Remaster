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
    GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        back.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoHome);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
