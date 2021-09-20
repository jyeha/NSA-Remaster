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
        //select_operator.AddComponent<SaveforBtn>();

        // 정보 가져오기
        OperatorClass info;
        info = clicked.GetComponent<SaveforBtn>().oper_info;
        Debug.Log("op_code: "+ info.op_code);
        Debug.Log("op_name: "+ info.name);
        Debug.Log("op_rare: "+ info.rare);
        Debug.Log("op_rank: "+ info.rank);
        Debug.Log("op_level: "+ info.level);
        Debug.Log("op_attack: "+ info.attack);
        Debug.Log("op_cost: "+ info.cost);


        if(select_operator.GetComponent<SaveforBtn>() == null){
            Debug.Log("null");
        }
        if(select_operator.GetComponent<SaveforBtn>().oper_info == null){
            Debug.Log("oper_info == null");
        }
        //Debug.Log(select_operator.GetComponent<SaveforBtn>().oper_info);
        select_operator.GetComponent<SaveforBtn>().oper_info.SetProperty(info);

        // select.GetComponent<SaveforBtn>().oper_info.op_code = clicked.GetComponent<SaveforBtn>().oper_info.op_code;
        // select.GetComponent<SaveforBtn>().oper_info.name = clicked.GetComponent<SaveforBtn>().oper_info.name;
        // select.GetComponent<SaveforBtn>().oper_info.rare = clicked.GetComponent<SaveforBtn>().oper_info.rare;
        // select.GetComponent<SaveforBtn>().oper_info.rank = clicked.GetComponent<SaveforBtn>().oper_info.rank;
        // select.GetComponent<SaveforBtn>().oper_info.level = clicked.GetComponent<SaveforBtn>().oper_info.level;
        // select.GetComponent<SaveforBtn>().oper_info.attack = clicked.GetComponent<SaveforBtn>().oper_info.attack;
        // select.GetComponent<SaveforBtn>().oper_info.cost = clicked.GetComponent<SaveforBtn>().oper_info.cost;
        // select.GetComponent<SaveforBtn>().oper_info.img_name = clicked.GetComponent<SaveforBtn>().oper_info.img_name;

        //gamemanager.GetComponent<GameManager>().GotoOperatorDetail;
        SceneManager.LoadScene("OperatorDetailScene");

    }
}
