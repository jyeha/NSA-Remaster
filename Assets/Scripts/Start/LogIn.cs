using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LogIn : MonoBehaviour
{
    GameObject gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

    }

    // 유저 데이터가 있는지 확인 후 load data
    public void Load_UserData(){
        UserClass tempUser;
        tempUser = gamemanager.GetComponent<GameManager>().LoadJsonFile<UserClass>(Application.dataPath,"Scripts/Data/UserData");
        //Debug.Log(tempUser.ID);
        if(tempUser == null){
            Debug.Log("No User Data");
        }
        else{
            gamemanager.GetComponent<GameManager>().UserData = tempUser;
            SceneManager.LoadScene("HomeScene");
        }


    }

}
