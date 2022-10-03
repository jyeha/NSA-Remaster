using Assets.Scripts.NewStage;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class StageSet : MonoBehaviour
{
    [SerializeField] GameObject DeckPanel;
    [SerializeField] GameObject TowerImage;
    [SerializeField] GameObject Ground;
    [SerializeField] GameObject Hill;
    [SerializeField] GameObject TowerSD;
    [SerializeField] GameObject DeployGuide;
    private Deck userDeck;
    
    GameObject deckInfo;
    GameObject stageInfo;
    
    private void Awake()
    {
        deckInfo = GameObject.Find("DeckInfo");
    }

    private void Start()
    {
        //deckInfo = GameObject.Find("DeckInfo");
        MakeList(deckInfo.GetComponent<Deck>());

        Ground.SetActive(false);
        Hill.SetActive(false);
        TowerSD.SetActive(false);
        DeployGuide.SetActive(false);
    }

    private void MakeList(Deck deck)
    {
        foreach(var member in deck.Members)
        {
            // 우측 하단 드래그가 가능한 버튼으로 생성
            GameObject btn = Instantiate(TowerImage, DeckPanel.transform);

            if(btn.TryGetComponent<Tower>(out var tower))
            {
                //tower = member;
                tower.SetValue(member);

                if(btn.TryGetComponent<TowerDeployment>(out var towerDeployment))
                {
                    Debug.Log(tower.ID);
                    Debug.Log(tower.Type);
                    if (tower.Type == 1)
                    {
                        //Debug.Log("지상");
                        towerDeployment.TowerDeployPoint = Ground;
                    }
                    else if (tower.Type == 2)
                    {
                        //Debug.Log("언덕");
                        towerDeployment.TowerDeployPoint = Hill;
                    }

                    towerDeployment.TowerSD = GameObject.Find("TowerSD");
                    towerDeployment.DeployGuide = GameObject.Find("DeployGuide");
                }
            }
            

            // 버튼의 이미지, 코스트 출력
            //btn.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Characters/" + member.ID);
            //btn.transform.GetChild(2).GetComponent<Text>().text = "COST: " + member.Cost;

            // 멤버의 정보를 버튼으로 옮기기

        }
    }
}
