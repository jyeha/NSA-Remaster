using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoViewer : MonoBehaviour
{
    public bool isOn;

    [SerializeField]
    private TowerAttackRange towerAttackRange;
    [SerializeField]
    private TowerCount towerCnt;

    private GameObject SelectedTower;


    public Text nameText;
    public Text rareText;
    public Text levelText;
    public Text costText;
    public Text damageText;
    public Image towerImage;
    public Button sellButton;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        sellButton.onClick.AddListener(TowerSell);
        OffPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            isOn = false;
            OffPanel();
        }
        
    }

    public void OnPanel(GameObject tower){
        SelectedTower = tower;
        isOn = true;
        gameObject.SetActive(true);
        PanelSetUp(tower);
        towerAttackRange.OnAttackRange(tower.transform.position+Vector3.up*0.7f, 2.0f);
    }

    public void OffPanel(){
        isOn = false;
        gameObject.SetActive(false);
        towerAttackRange.OffAttackRange();
    }

    void PanelSetUp(GameObject tower){
        TowerInformation towerInfo = tower.GetComponent<TowerInformation>();
        nameText.text = "이름 : " + towerInfo.name;
        rareText.text = "레어도 : " + towerInfo.rare;
        levelText.text = "레벨 : " + towerInfo.level;
        costText.text = "코스트 : " + towerInfo.cost;
        damageText.text = "대미지 : " + towerInfo.attack;
        towerImage.sprite = Resources.Load<Sprite>("Images/Characters/"+towerInfo.img_name);
    }

    void TowerSell(){
        SelectedTower.GetComponent<TowerInformation>().ownerTile.IsBuild = false;
        towerCnt.towerCount--;
        Destroy(SelectedTower);
        OffPanel();
    }
}
