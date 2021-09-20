using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public Button start;
    GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        start.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoHome);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
