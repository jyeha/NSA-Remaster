using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UIElements;

namespace Assets.Scripts.NewStage
{
    public class TowerDeployment : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private int currentCost;
        [SerializeField] private GameObject _towerDeployPoint;
        [SerializeField] private GameObject _towerSD;
        [SerializeField] private GameObject _deployGuide;
        [SerializeField] private DeployManager _deployManager;

        private AsyncOperationHandle<Sprite> spriteOperation;
        private SpriteRenderer _towerSpriteRenderer;

        private Tower tower;
        private bool _canDeploy = false;

        public GameObject TowerDeployPoint { get { return _towerDeployPoint; } set { _towerDeployPoint = value; } }
        public GameObject TowerSD { get { return _towerSD; } set { _towerSD = value; } }
        public GameObject DeployGuide { get { return _deployGuide; } set { _deployGuide = value; } }



        void Start()
        {
            if(TryGetComponent<Tower>(out var tower))
            {
                this.tower = tower;
            }

            //if (_towerSD.TryGetComponent<SpriteRenderer>(out var sprite))
            //{
            //    _towerSpriteRenderer = sprite;
            //}

            if(GameObject.Find("DeployManager").TryGetComponent<DeployManager>(out var deploymanager))
            {
                _deployManager = deploymanager;
            }
            

            spriteOperation = Addressables.LoadAssetAsync<Sprite>(tower.Name);

            _canDeploy = false;
            currentCost = 30;
        }

        // Update is called once per frame
        void Update()
        {
            if(tower.Cost < currentCost && !_canDeploy)
            {
                _canDeploy = true;
            }
            else if(tower.Cost > currentCost && _canDeploy)   
            {
                _canDeploy = false;
            }
        }

        //void SetTowerSD(AsyncOperationHandle<Sprite> obj)
        //{
        //    switch (obj.Status)
        //    {
        //        case AsyncOperationStatus.Succeeded:
        //            _towerSpriteRenderer.sprite = obj.Result;
        //            break;

        //        case AsyncOperationStatus.Failed:
        //            Debug.Log("스프라이트 로드 실패");
        //            break;

        //        default:
        //            break;
        //    }
        //}

        // 타워 배치 : OnBeginDrag, OnDrag, OnEndDrag
        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            if (!_canDeploy)
            {
                Debug.Log("배치 불가");
                return;
            }

            //_towerSD.SetActive(true);   
            Addressables.InstantiateAsync(tower.Name + "Tower").Completed += op =>
            {
                if (op.Status == AsyncOperationStatus.Succeeded)
                {
                    _towerSD = op.Result;
                }
            };

            _towerDeployPoint.SetActive(true);
            _deployManager.SelectedTower = gameObject;

            //spriteOperation.Completed += SetTowerSD;
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if (!_canDeploy)
            {
                return;
            }

            if(_towerSD != null)
            {
                // 타워SD가 마우스를 따라다니도록
                _towerSD.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                {
                    Debug.Log(hit.transform.tag);
                    if (hit.transform.CompareTag("TowerPoints"))
                    {
                        Tile tile = hit.transform.GetComponent<Tile>();
                        if (!tile.IsBuild)
                        {
                            _towerSD.transform.position = tile.transform.position;
                        }

                    }
                }
            }

        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hit, Mathf.Infinity))
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.CompareTag("TowerPoints"))
                {
                    Tile tile = hit.transform.GetComponent<Tile>();

                    // 타워 배치
                    if (!tile.IsBuild)
                    {
                        Vector3 position = hit.transform.position + Vector3.back;

                        _deployManager.SelectedTile = tile;
                        _deployManager.SelectedPosition = position;

                        // 방향을 설정하는 UI 표시
                        SetTowerDirection(position);

                        _towerDeployPoint.SetActive(false);
                        return;

                    }
                    else
                    {
                        
                    }
                }
                else
                {

                }
            }
            else
            {

            }

            Destroy(_towerSD);
            _towerDeployPoint.SetActive(false);
            return;

        }

        void SetTowerDirection(Vector3 position)
        {
            _deployGuide.SetActive(true);
            _deployGuide.transform.position = position;

            return;
        }

        void TowerInstantiate(Vector3 position)
        {
            Addressables.InstantiateAsync(tower.Name + "Tower", position, Quaternion.identity);
            _towerSD.SetActive(false);
        }
    }
}