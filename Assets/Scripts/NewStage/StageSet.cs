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
            // ���� �ϴ� �巡�װ� ������ ��ư���� ����
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
                        //Debug.Log("����");
                        towerDeployment.TowerDeployPoint = Ground;
                    }
                    else if (tower.Type == 2)
                    {
                        //Debug.Log("���");
                        towerDeployment.TowerDeployPoint = Hill;
                    }

                    towerDeployment.TowerSD = GameObject.Find("TowerSD");
                    towerDeployment.DeployGuide = GameObject.Find("DeployGuide");
                }
            }
            

            // ��ư�� �̹���, �ڽ�Ʈ ���
            //btn.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Characters/" + member.ID);
            //btn.transform.GetChild(2).GetComponent<Text>().text = "COST: " + member.Cost;

            // ����� ������ ��ư���� �ű��

        }
    }
}
