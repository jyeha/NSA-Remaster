using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class OnClick_Detail : MonoBehaviour
{
    GameObject gamemanager;
    public GameObject selectPrefab;

    //public int operator_code;

    public void Selected(){
        //gamemanager = GameObject.Find("GameManager");

        GameObject clicked = EventSystem.current.currentSelectedGameObject;
        GameObject select_operator = (GameObject)Instantiate(selectPrefab);
        select_operator.gameObject.name = clicked.name;
        select_operator.gameObject.tag = "Selected";

        DontDestroyOnLoad(select_operator);

        // 정보 가져오기
        OperatorClass info;
        info = clicked.GetComponent<SaveforBtn>().oper_info;


        if(select_operator.GetComponent<SaveforBtn>() == null){
            Debug.Log("null");
        }
        if(select_operator.GetComponent<SaveforBtn>().oper_info == null){
            Debug.Log("oper_info == null");
        }
        select_operator.GetComponent<SaveforBtn>().oper_info.SetProperty(info);

        SceneManager.LoadScene("OperatorDetailScene");

    }
}
