using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaPull : MonoBehaviour
{
    //GameObject gamemanager;
    //public List<OperatorClass> deck = new List<OperatorClass>();
    // public int total = 0;
    // public List<OperatorClass> pullResult = new List<OperatorClass>();

    // public void ResultSelect(){
    //     pullResult.Add(RandomPull());
    //     //Debug.Log(pullResult[0].op_code);
    // }

    // public void ResultSelect10(){
    //     for(int i=0;i<10;i++){
    //         pullResult.Add(RandomPull());
    //         //Debug.Log(pullResult[i].op_code);
    //     }
    // }

    // public OperatorClass RandomPull(){
    //     int weight = 0;
    //     int selectNum = 0;
    //     selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

    //     for(int i=0; i<gamemanager.GetComponent<GameManager>().PullList.AllOperatorList.Count;i++){
    //         if(selectNum <= weight){
    //             OperatorClass temp = new OperatorClass();
    //             temp.SetProperty(gamemanager.GetComponent<GameManager>().PullList.AllOperatorList[i]);
    //             Debug.Log("Result: "+ temp.op_code);
    //             return temp;
    //         }
    //     }

    //     return null; 
    // }

    void Start(){
        // gamemanager = GameObject.Find("GameManager");
        // Debug.Log("PullList count : " + gamemanager.GetComponent<GameManager>().PullList.AllOperatorList.Count);
        // for(int i=0;i<gamemanager.GetComponent<GameManager>().PullList.AllOperatorList.Count;i++){
        //     total += gamemanager.GetComponent<GameManager>().PullList.AllOperatorList[i].weight;
        // }

        // oneTime.onClick.AddListener(ResultSelect);
        // tenTimes.onClick.AddListener(ResultSelect10);

    }
}
