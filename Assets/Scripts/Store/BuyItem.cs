using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyItem : MonoBehaviour
{
    public GameObject popupPanel;
    public Image sellImage;
    public Image buyImage;
    public Text sellText;
    public Text buyText;

    public Text goldText;
    public Text crystalText;

    public Button YesButton;
    public Button NoButton;

    public GameObject selected;

    private SellInformation sellInfo;

    GameObject gameManager;
    private UserClass userData;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        selected = GameObject.Find("Selected");
        userData = gameManager.GetComponent<GameManager>().UserData;
        popupPanel.SetActive(false);
    }

    public void Select(){
        sellInfo = GetComponent<SellInformation>();
        selected.GetComponent<SellInformation>().sellProduct = sellInfo.sellProduct;
        selected.GetComponent<SellInformation>().sellAmount = sellInfo.sellAmount;
        selected.GetComponent<SellInformation>().buyProduct = sellInfo.buyProduct;
        selected.GetComponent<SellInformation>().buyAmount = sellInfo.buyAmount;
        OpenPopup();
    }

    void OpenPopup(){
        popupPanel.SetActive(true);
        sellImage.sprite = Resources.Load<Sprite>("Images/UI/"+sellInfo.sellProduct);
        buyImage.sprite = Resources.Load<Sprite>("Images/UI/"+sellInfo.buyProduct);
        sellText.text = sellInfo.sellAmount.ToString()+"개로";
        buyText.text = sellInfo.buyAmount.ToString()+"개를";
    }

}
