using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    //[SerializeField]
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField]
    private TowerInfoViewer towerInfoViewer;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            // Vector3 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            // RaycastHit2D hit = Physics2D.Raycast(pos, transform.forward, Mathf.Infinity);
            // if(hit){
            //     if(hit.transform.CompareTag("Tower")){
            //         if(towerInfoViewer.isOn)
            //             towerInfoViewer.OffPanel();
            //         else if(!towerInfoViewer.isOn)
            //             towerInfoViewer.OnPanel(hit.collider.gameObject);
            //     }
            //     // else if(towerInfoViewer.isOn && !hit.transform.CompareTag("TowerPanel")){
            //     //     towerInfoViewer.OffPanel();
            //     // }
            // }
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
                if(hit.transform.CompareTag("Tower")){
                    if(towerInfoViewer.isOn)
                        towerInfoViewer.OffPanel();
                    else if(!towerInfoViewer.isOn)
                        towerInfoViewer.OnPanel(hit.collider.gameObject);
                }
                else if(towerInfoViewer.isOn && !hit.transform.CompareTag("TowerPanel")){
                    towerInfoViewer.OffPanel();
                }
            }
        }
    }
}
