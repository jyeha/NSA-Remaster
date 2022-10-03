using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEditor.Experimental.GraphView;

namespace Assets.Scripts.NewStage
{
    public class TowerDeploymentDirection : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public enum Direction { None, Up, Down, Right, Left };
        private DeployManager deployManager;
        [SerializeField] private Direction direction;
        [SerializeField] private Button Cancel;
        [SerializeField] private GameObject TowerSD;
        [SerializeField] private GameObject Collider;
        [SerializeField] private GameObject DirectionGuide;

        void Start()
        {
            deployManager = GameObject.Find("DeployManager").GetComponent<DeployManager>();

        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            direction = Direction.None;
            TowerSD = GameObject.Find("HillTowerSD");
            Collider = TowerSD.transform.GetChild(0).gameObject;
            DirectionGuide = gameObject.transform.parent.gameObject;

            gameObject.transform.localPosition = Vector3.zero;
            Collider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));

            float x = Mathf.Clamp(transform.localPosition.x, -120.0f, 120.0f);
            float y = Mathf.Clamp(transform.localPosition.y, -120.0f, 120.0f);

            if(Mathf.Abs(x) + Mathf.Abs(y) > 120)
            {
                if (x == 120f || x == -120f) y = 0;
                else if (y == 120f || y == -120f) x = 0;
                else if (0 <= x && 0 <= y) y = 120f - x;
                else if (0 <= x && y < 0) y = -120f + x;
                else if (x < 0 && 0 <= y) y = 120f + x;
                else if(x<0 && y<0) y = -120f - x;

                transform.localPosition = new Vector3(x, y, 0.0f);
            }

            if (transform.localPosition.x == 120f)
            {
                direction = Direction.Right;
                Collider.SetActive(true);
                Collider.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (transform.localPosition.x == -120f)
            {
                direction = Direction.Left;
                Collider.SetActive(true);
                Collider.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (transform.localPosition.y == 120f)
            {
                direction = Direction.Up;
                Collider.SetActive(true);
                Collider.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (transform.localPosition.y == -120f)
            {
                direction = Direction.Down;
                Collider.SetActive(true);
                Collider.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else 
            {
                direction = Direction.None;
                Collider.transform.rotation = Quaternion.Euler(0, 0, 0);
                Collider.SetActive(false);
            }

        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            // 만약 어느 콜라이더에도 안닿고 중앙에 있으면 그대로
            if(direction == Direction.None)
            {
                Cancel.gameObject.SetActive(true);
                transform.localPosition = Vector3.zero;
                return;
            }
            // 만약 한 콜라이더에 닿았으면 그 방향 그대로 배치
            else
            {
                Deploy();
                gameObject.transform.localPosition = Vector3.zero;
                Collider.transform.rotation = Quaternion.Euler(0, 0, 0);
                DirectionGuide.SetActive(false);
            }
        }

        void Deploy()
        {
            Tower tower = deployManager.SelectedTower.GetComponent<Tower>();
            Addressables.InstantiateAsync(tower.Name + "Tower", deployManager.SelectedPosition, Quaternion.identity).Completed += op =>
            {
                if(op.Status == AsyncOperationStatus.Succeeded)
                {
                    GameObject DeployedTower = op.Result;
                    DeployedTower.GetComponent<Tower>().StartAttack();
                }
            };
            TowerSD.SetActive(false);



            // 현재 위치한 타일 isbuild = true로 바꾸기
            // 우측 아래 오퍼 목록에서 지우기
            // 코스트 감소, 배치 가능 수 감소

            deployManager.SelectedTile.IsBuild = true;
            deployManager.SelectedTower.SetActive(false);
        }

        public void Cancle()
        {
            DirectionGuide = gameObject.transform.parent.gameObject;
            TowerSD = GameObject.Find("TowerSD");
            DirectionGuide.SetActive(false);
            TowerSD.SetActive(false);
            Debug.Log("취소");
        }
    }
}