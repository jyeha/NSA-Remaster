using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperatorDetailManager : MonoBehaviour
{
    public Button back;
    public Button menu;
    public Button levelup;
    public Button awake;
    public Image Character_image;
    public Text Name;
    public Text Rare;
    public Text Level;
    public Text Attack;
    public Text Cost;

    GameObject gamemanager;
    GameObject select;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        select = GameObject.FindWithTag("Selected");

        SetScreen();
        GameObject.Destroy(select);
        back.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoOperator);
        menu.onClick.AddListener(gamemanager.GetComponent<GameManager>().GotoHome);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetScreen(){
        Character_image.sprite = Resources.Load<Sprite>("Images/Characters/" + select.GetComponent<SaveforBtn>().oper_info.img_name);

        Name.text = select.GetComponent<SaveforBtn>().oper_info.name;
        Level.text = "Lv. " + select.GetComponent<SaveforBtn>().oper_info.level.ToString();
        Rare.text = select.GetComponent<SaveforBtn>().oper_info.rare;
        Attack.text = "공격력: " + select.GetComponent<SaveforBtn>().oper_info.attack.ToString();
        Cost.text = "코스트: " + select.GetComponent<SaveforBtn>().oper_info.cost.ToString();

    }
}
