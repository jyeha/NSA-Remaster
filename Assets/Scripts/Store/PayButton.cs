using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PayButton : MonoBehaviour
{
    public GameObject popupPanel;
    public GameObject toastPanel;
        
    public Text goldText;
    public Text crystalText;
    public Text toastText;

    private SellInformation sellInfo;
    private bool buy;

    GameObject gameManager;
    private UserClass userData;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        sellInfo = GameObject.Find("Selected").GetComponent<SellInformation>();
        userData = gameManager.GetComponent<GameManager>().UserData;
        buy = false;
        toastPanel.SetActive(false);
    }

    public void Buy(){
        if(sellInfo.sellProduct == "Gold"){
            if(userData.gold >= sellInfo.sellAmount){
                // 골드 감소
                userData.gold -= sellInfo.sellAmount;

                // 구매
                if(sellInfo.buyProduct == "Potion") userData.userItem.potion += sellInfo.buyAmount;
                else if(sellInfo.buyProduct == "Crystal") userData.crystal += sellInfo.buyAmount;

                buy = true;

                ShowToastMessage();
            }
            else{
                ShowToastMessage();
            }
        }
        else if(sellInfo.sellProduct == "Crystal"){
            if(userData.crystal >= sellInfo.sellAmount){
                userData.crystal -= sellInfo.sellAmount;
                if(sellInfo.buyProduct == "Gold") userData.gold += sellInfo.buyAmount;

                buy = true;

                ShowToastMessage();
            }
            else{
                ShowToastMessage();
            }
        }

        goldText.text = userData.gold.ToString();
        crystalText.text = userData.crystal.ToString();

        //popupPanel.SetActive(false);

    }

    public void Cancel(){
        popupPanel.SetActive(false);
    }

    public void ShowToastMessage(){
        toastPanel.SetActive(true);
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut(){
        if(buy){
            toastText.text = "구매 완료되었습니다.";
        }
        else{
            toastText.text = "재화가 부족합니다";
        }

        buy = false;

        Color c = toastPanel.GetComponent<Image>().color;
        c.a = 0.7f;
        toastPanel.GetComponent<Image>().color = c;

        while(c.a >= 0.0f){
            c.a -= Time.deltaTime;
            toastPanel.GetComponent<Image>().color = c;
            yield return null;
        }
        
        toastPanel.SetActive(false);
    }
}
