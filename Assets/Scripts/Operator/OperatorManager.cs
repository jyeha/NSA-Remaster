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
    
    List<OperatorClass> OpList;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        back.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoHome);
        //OpList = gamemanager.GetComponent<GameManager>().LoadJsonFile<OwnOperatorList>(Application.dataPath,"Scripts/Data/operatorlist");
        OpList = gamemanager.GetComponent<GameManager>().UserData.own_op_list;


        for(int i=0;i<OpList.Count;i++){
            OperatorClass op = OpList[i];
            Debug.Log("operator code : "+ op.op_code);
            CreateOperators(op);
        }
    }

    // Update is called once per frame
    void Update()
    {
        OpList = gamemanager.GetComponent<GameManager>().UserData.own_op_list;

        for(int i=0;i<OpList.Count;i++){
            OperatorClass op = OpList[i];
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

    }
}
