using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSettingManager : MonoBehaviour
{
    public GameObject DeckPanel;
    public GameObject TowerImage;
    public GameObject ShowTowerPoint;
    GameObject gamemanager;
    GameObject playerManager;
    GameObject deckInfo;
    GameObject stageInfo;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        deckInfo = GameObject.Find("DeckInfo");
        playerManager = GameObject.Find("PlayerManager");
        stageInfo = GameObject.Find("StageInfo");

        Destroy(stageInfo);
        DeckSetUp(deckInfo.GetComponent<DeckInfo>().SelectedDeckInfo);

        Time.timeScale = 1;
        ShowTowerPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeckSetUp(DeckClass SelectedDeckInfo){
        for(int i=0;i<SelectedDeckInfo.deck_member.Count;i++){
            GameObject btn = Instantiate(TowerImage, DeckPanel.transform);

            btn.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Characters/"+ SelectedDeckInfo.deck_member[i].img_name);
            btn.transform.GetChild(2).GetComponent<Text>().text = "COST: "+SelectedDeckInfo.deck_member[i].cost;

            btn.GetComponent<TowerInformation>().op_code = SelectedDeckInfo.deck_member[i].op_code;
            btn.GetComponent<TowerInformation>().name = SelectedDeckInfo.deck_member[i].name;
            btn.GetComponent<TowerInformation>().rare = SelectedDeckInfo.deck_member[i].rare;
            btn.GetComponent<TowerInformation>().rank = SelectedDeckInfo.deck_member[i].rank;
            btn.GetComponent<TowerInformation>().level = SelectedDeckInfo.deck_member[i].level;
            btn.GetComponent<TowerInformation>().attack = SelectedDeckInfo.deck_member[i].attack;
            btn.GetComponent<TowerInformation>().cost = SelectedDeckInfo.deck_member[i].cost;
            btn.GetComponent<TowerInformation>().img_name = SelectedDeckInfo.deck_member[i].img_name;
            btn.GetComponent<TowerInformation>().weight = SelectedDeckInfo.deck_member[i].weight;
            btn.GetComponent<TowerInformation>().tempSDRoute = SelectedDeckInfo.deck_member[i].tempSDRoute;
            btn.GetComponent<TowerInformation>().towerSDRoute = SelectedDeckInfo.deck_member[i].towerSDRoute;

            btn.GetComponent<TowerDrag>().ShowTowerPoint = this.ShowTowerPoint;


            btn.GetComponent<TowerDrag>().cost = playerManager.GetComponent<Cost>();
            btn.GetComponent<TowerDrag>().BuildCost = btn.GetComponent<TowerInformation>().cost;
            //TowerImage.GetComponent<Image>().sprite = 
        }
    }
}
