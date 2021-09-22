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

    // Start is called before the first frame update
    void Start()
    {
        List<OperatorClass> GachaList;

        gamemanager = GameObject.Find("GameManager");
        result = GameObject.FindWithTag("gachaResult");

        GachaList = result.GetComponent<SaveGachaResult>().gacha_result;
        GameObject.Destroy(result);

        ShowResult(GachaList);
        AddResulttoOwnOperator(GachaList);

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
}
