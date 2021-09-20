using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperatorManager : MonoBehaviour
{
    public Button back;
    public Button menu;
    public GameObject op_;
    public GameObject parent_panel;
    GameObject gamemanager;
    
    OwnOperatorList OpList;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        back.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoHome);
        OpList = gamemanager.GetComponent<GameManager>().LoadJsonFile<OwnOperatorList>(Application.dataPath,"Scripts/Data/operatorlist");


        for(int i=0;i<OpList.OperatorList.Count;i++){
            OperatorClass op = OpList.OperatorList[i];
            Debug.Log("operator code : "+ op.op_code);
            CreateOperators(op);
            //SetInfo(op);
        }
    }

    // Update is called once per frame
    void Update()
    {
        OpList = gamemanager.GetComponent<GameManager>().LoadJsonFile<OwnOperatorList>(Application.dataPath,"Scripts/Data/operatorlist");

        for(int i=0;i<OpList.OperatorList.Count;i++){
            OperatorClass op = OpList.OperatorList[i];
            //Debug.Log("operator code : "+ op.op_code);
            //CreateOperators(op);
            //SetInfo(op);
        }
    }

    public void CreateOperators(OperatorClass op){
        GameObject btn = (GameObject)Instantiate(op_);
        btn.transform.SetParent(parent_panel.transform);

        btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Characters/" + op.img_name);
        btn.name = op.op_code.ToString();

        // text
        GameObject tmppanel = btn.transform.Find("Panel").gameObject;
        GameObject rareText = btn.transform.Find("rareText").gameObject;
        GameObject nameText = tmppanel.transform.Find("NameText").gameObject;
        GameObject levelText = tmppanel.transform.Find("LevelText").gameObject;
        Text nametxt = nameText.GetComponent<Text>();
        Text leveltxt = levelText.GetComponent<Text>();
        Text raretxt = rareText.GetComponent<Text>();
        nametxt.text = op.name;
        leveltxt.text = "Lv. " + op.level;
        raretxt.text = op.rare;

        btn.GetComponent<SaveforBtn>().oper_info.SetProperty(op);

        Debug.Log("op_code: "+ btn.GetComponent<SaveforBtn>().oper_info.op_code);
        Debug.Log("op_name: "+ btn.GetComponent<SaveforBtn>().oper_info.name);
        Debug.Log("op_rare: "+ btn.GetComponent<SaveforBtn>().oper_info.rare);
        Debug.Log("op_rank: "+ btn.GetComponent<SaveforBtn>().oper_info.rank);
        Debug.Log("op_level: "+ btn.GetComponent<SaveforBtn>().oper_info.level);
        Debug.Log("op_attack: "+ btn.GetComponent<SaveforBtn>().oper_info.attack);
        Debug.Log("op_cost: "+ btn.GetComponent<SaveforBtn>().oper_info.cost);
    }
}
