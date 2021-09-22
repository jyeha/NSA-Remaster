using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GachaManager : MonoBehaviour
{
    public Button back;
    public Button menu;
    public Button oneTime;
    public Button tenTimes;

    GameObject gamemanager;
    
    public int total = 0;
    public List<OperatorClass> pullResult = new List<OperatorClass>();
    public GameObject saveList;

    public void ResultSelect(){
        if(gamemanager.GetComponent<GameManager>().UserData.crystal < 600){
            Debug.Log("크리스탈이 부족합니다.");
        }
        else{
            GameObject listObject = (GameObject)Instantiate(saveList);
            listObject.gameObject.name = "gachaResult";
            listObject.gameObject.tag = "gachaResult";
            DontDestroyOnLoad(listObject);

            pullResult.Add(RandomPull());
            Debug.Log(pullResult[0].op_code);
            
            listObject.GetComponent<SaveGachaResult>().gacha_result = pullResult;

            gamemanager.GetComponent<GameManager>().UserData.crystal -= 600;

            SceneManager.LoadScene("GachaResultScene");
        }
    }

    public void ResultSelect10(){
        if(gamemanager.GetComponent<GameManager>().UserData.crystal < 6000){
            Debug.Log("크리스탈이 부족합니다.");
        }
        else{
            GameObject listObject = (GameObject)Instantiate(saveList);
            listObject.gameObject.name = "gachaResult";
            listObject.gameObject.tag = "gachaResult";
            DontDestroyOnLoad(listObject);
            
            for(int i=0;i<10;i++){
                pullResult.Add(RandomPull());
                Debug.Log(pullResult[i].op_code);
            }

            listObject.GetComponent<SaveGachaResult>().gacha_result = pullResult;

            gamemanager.GetComponent<GameManager>().UserData.crystal -= 6000;

            SceneManager.LoadScene("GachaResultScene");
        }
    }

    public OperatorClass RandomPull(){
        int weight = 0;
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for(int i=0; i<gamemanager.GetComponent<GameManager>().PullList.AllOperatorList.Count;i++){
            weight += gamemanager.GetComponent<GameManager>().PullList.AllOperatorList[i].weight;
            if(selectNum <= weight){
                OperatorClass temp = new OperatorClass();
                temp.SetProperty(gamemanager.GetComponent<GameManager>().PullList.AllOperatorList[i]);
                return temp;
            }
        }

        return null; 
    }


    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");

        for(int i=0;i<gamemanager.GetComponent<GameManager>().PullList.AllOperatorList.Count;i++){
            total += gamemanager.GetComponent<GameManager>().PullList.AllOperatorList[i].weight;
        }
        
        back.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoHome);
        oneTime.onClick.AddListener(ResultSelect);
        tenTimes.onClick.AddListener(ResultSelect10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
