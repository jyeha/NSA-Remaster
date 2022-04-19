using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GachaResultManager : MonoBehaviour
{
    public Button onemore;
    public Button back;
    public GameObject _panel;

    GameObject gamemanager;
    GameObject result;
    public GameObject _icon;
    public GameObject saveList;

    [SerializeField]
    private List<OperatorClass> pullResult = new List<OperatorClass>();
    [SerializeField]
    private List<OperatorClass> GachaList;
    public int type;
    
    private int total;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        result = GameObject.FindWithTag("gachaResult");

        for(int i=0;i<gamemanager.GetComponent<GameManager>().PullList.AllOperatorList.Count;i++){
            total += gamemanager.GetComponent<GameManager>().PullList.AllOperatorList[i].weight;
        }

        GachaList = result.GetComponent<SaveGachaResult>().gacha_result;
        type = result.GetComponent<SaveGachaResult>().gachaType;
        GameObject.Destroy(result);

        ShowResult(GachaList);
        AddResulttoOwnOperator(GachaList);

        onemore.onClick.AddListener(OneMorePull);
        back.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoGacha);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowResult(List<OperatorClass> GachaList){
        if(GachaList.Count == 1){
            OperatorClass temp = GachaList[0];
            GameObject icon = (GameObject)Instantiate(_icon);
            icon.transform.SetParent(_panel.transform);

            icon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Characters/" + temp.img_name);
            icon.transform.Find("rareText").gameObject.GetComponent<Text>().text = temp.rare;
        }
        else{
            for(int i=0;i<GachaList.Count;i++){
                OperatorClass temp = GachaList[i];
                GameObject icon = (GameObject)Instantiate(_icon);
                icon.transform.SetParent(_panel.transform);

                icon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Characters/" + temp.img_name);
                icon.transform.Find("rareText").gameObject.GetComponent<Text>().text = temp.rare;icon.transform.Find("rareText").gameObject.GetComponent<Text>().text = temp.rare;
            }
        }
    }

    // 중복 체크, 없는 오퍼레이터면 리스트에 추가
    void AddResulttoOwnOperator(List<OperatorClass> GachaList){
        for(int i=0;i<GachaList.Count;i++){
            OperatorClass tmp = GachaList[i];
            OperatorClass find = gamemanager.GetComponent<GameManager>().UserData.own_op_list.Find(x => x.op_code == tmp.op_code);
            if(find == null){
                gamemanager.GetComponent<GameManager>().UserData.own_op_list.Add(tmp);
            }
            else{
                // 돌파 재료
            }
        }
        gamemanager.GetComponent<GameManager>().UserData.own_op_list = gamemanager.GetComponent<GameManager>().UserData.own_op_list.OrderBy(x => x.op_code).ToList();
    }

    void OneMorePull(){

        if(type == 1)   ResultSelect();
        else if(type == 10) ResultSelect10();

    }

    public void ResultSelect(){
        if(gamemanager.GetComponent<GameManager>().UserData.crystal < 600){
            Debug.Log("크리스탈이 부족합니다.");
        }
        else{
            List<OperatorClass> pullResult = new List<OperatorClass>();

            GameObject listObject = (GameObject)Instantiate(saveList);
            listObject.gameObject.name = "gachaResult";
            listObject.gameObject.tag = "gachaResult";
            DontDestroyOnLoad(listObject);

            pullResult.Add(RandomPull());
            Debug.Log(pullResult[0].op_code);
            
            listObject.GetComponent<SaveGachaResult>().gacha_result = pullResult;
            listObject.GetComponent<SaveGachaResult>().gachaType = 1;

            gamemanager.GetComponent<GameManager>().UserData.crystal -= 600;

            SceneManager.LoadScene("GachaResultScene");

        }
    }

    public void ResultSelect10(){
        if(gamemanager.GetComponent<GameManager>().UserData.crystal < 6000){
            Debug.Log("크리스탈이 부족합니다.");
        }
        else{
            List<OperatorClass> pullResult = new List<OperatorClass>();

            GameObject listObject = (GameObject)Instantiate(saveList);
            listObject.gameObject.name = "gachaResult";
            listObject.gameObject.tag = "gachaResult";
            DontDestroyOnLoad(listObject);
            
            for(int i=0;i<10;i++){
                pullResult.Add(RandomPull());
                Debug.Log(pullResult[i].op_code);
            }

            listObject.GetComponent<SaveGachaResult>().gacha_result = pullResult;
            listObject.GetComponent<SaveGachaResult>().gachaType = 10;

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

}
