/* 우측 하단의 타워 버튼을 드래그하면 타워를 설치할 수 있음 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private GameObject SD, tempSD;
    private GameObject tempTowerSD, TowerSD, par;
    private Camera maincamera;
    private Ray ray;
    private RaycastHit hit;
    private bool isDragged = false;
    
    public Cost cost;
    public int BuildCost;
    public TowerCount tCount;
    public GameObject ShowTowerPoint;

    void Awake(){
        ShowTowerPoint = GameObject.Find("ShowTowerDeployPoint");
    }
    
    void Start(){
        maincamera = Camera.main;
        cost = GameObject.Find("PlayerManager").GetComponent<Cost>();
        tCount = GameObject.Find("PlayerManager").GetComponent<TowerCount>();
        //ShowTowerPoint = GameObject.Find("ShowTowerDeployPoint");
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData){
        if(cost.CurrentCost < gameObject.GetComponent<TowerInformation>().cost) return;
        if(tCount.MaxTowerCount < tCount.towerCount+1) return;
        
        tempSD = Resources.Load(gameObject.GetComponent<TowerInformation>().tempSDRoute) as GameObject;
        tempTowerSD = Instantiate(tempSD);
        isDragged = true;
        ShowTowerPoint.SetActive(true);
    }

    void IDragHandler.OnDrag(PointerEventData eventData){
        if(isDragged){
            tempTowerSD.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));

        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData){
        if(isDragged){
            Destroy(tempTowerSD);
            ray = maincamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
                if(hit.transform.CompareTag("TowerPoints")){
                    Tile tile = hit.transform.GetComponent<Tile>();

                    if(tile.IsBuild == false){
                        tile.IsBuild = true;
                        cost.CurrentCost -= BuildCost;
                        Vector3 position = hit.transform.position + Vector3.back;
                        SD = Resources.Load(gameObject.GetComponent<TowerInformation>().towerSDRoute) as GameObject;
                        TowerSD = Instantiate(SD, position, Quaternion.identity);
                        tCount.towerCount++;
                        // 타워 값 셋팅
                        DataSetUp(TowerSD, gameObject, tile);
                    }  
                }
            }
        }
        else{

        }
        isDragged = false;
        ShowTowerPoint.SetActive(false);
    }

    void DataSetUp(GameObject TowerSD, GameObject obj, Tile ownerTile){
        TowerSD.GetComponent<TowerInformation>().op_code = obj.GetComponent<TowerInformation>().op_code;
        TowerSD.GetComponent<TowerInformation>().name = obj.GetComponent<TowerInformation>().name;
        TowerSD.GetComponent<TowerInformation>().rare = obj.GetComponent<TowerInformation>().rare;
        TowerSD.GetComponent<TowerInformation>().rank = obj.GetComponent<TowerInformation>().rank;
        TowerSD.GetComponent<TowerInformation>().level = obj.GetComponent<TowerInformation>().level;
        TowerSD.GetComponent<TowerInformation>().attack = obj.GetComponent<TowerInformation>().attack;
        TowerSD.GetComponent<TowerInformation>().cost = obj.GetComponent<TowerInformation>().cost;
        TowerSD.GetComponent<TowerInformation>().img_name = obj.GetComponent<TowerInformation>().img_name;
        TowerSD.GetComponent<TowerInformation>().weight = obj.GetComponent<TowerInformation>().weight;
        TowerSD.GetComponent<TowerInformation>().tempSDRoute = obj.GetComponent<TowerInformation>().tempSDRoute;
        TowerSD.GetComponent<TowerInformation>().towerSDRoute = obj.GetComponent<TowerInformation>().towerSDRoute;

        // ownerTile: 타일이 설치된 타일 정보
        TowerSD.GetComponent<TowerInformation>().ownerTile = ownerTile;
    }
    
}
