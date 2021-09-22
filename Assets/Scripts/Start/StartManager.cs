using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public Button start;
    public Button exit;
    GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        exit.onClick.AddListener(GameQuit);
        start.onClick.AddListener(Load_UserData);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load_UserData(){
        UserClass tempUser;
        tempUser = gamemanager.GetComponent<GameManager>().LoadJsonFile<UserClass>(Application.dataPath,"Scripts/Data/UserData");
        if(tempUser == null){
            Debug.Log("No User Data");
            // 신규 유저 생성
            // 팝업 후 닉네임 입력 받기
        }
        else{
            gamemanager.GetComponent<GameManager>().UserData = tempUser;
            SceneManager.LoadScene("HomeScene");
        }
    }

    void GameQuit(){
        Application.Quit();
    }
}
