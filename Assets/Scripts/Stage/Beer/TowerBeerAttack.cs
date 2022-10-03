using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBeerAttack : MonoBehaviour
{
    [SerializeField]
    private float AttackTime;
    [SerializeField]
    private Transform BulletSpawnPoint;
    public List<GameObject> EnemyList = new List<GameObject>();
    private GameObject AttackTarget;
    public GameObject parent;
    public GameObject Bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Attack");
    }

    private IEnumerator Attack(){
        while(true){
            float minDistance = Mathf.Infinity;

            if(EnemyList.Count == 0)    AttackTarget = null;
            // 적 탐색
            for(int i=0;i<EnemyList.Count;i++){
                if(EnemyList[i].GetComponent<past_Enemy>().RemainDistance < minDistance){
                    minDistance = EnemyList[i].GetComponent<past_Enemy>().RemainDistance;
                    AttackTarget = EnemyList[i];
                }
                    
            }

            if(AttackTarget != null){
                // 공격
                if(AttackTarget.transform.position.x < parent.transform.position.x){
                    parent.GetComponent<SpriteRenderer>().flipX = false;
                }
                else{
                    parent.GetComponent<SpriteRenderer>().flipX = true;
                }
                GameObject _bullet = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
                _bullet.GetComponent<BulletBeerMove>().TargetSet(AttackTarget.transform);
                _bullet.GetComponent<BulletBeerMove>().BulletSetUp(gameObject.transform.parent.gameObject);
            }

            yield return new WaitForSeconds(AttackTime);
        }
    }

    void OnTriggerEnter2D(Collider2D o){
        if(o.tag == "Enemy"){
            EnemyList.Add(o.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D o){
        if(o.tag == "Enemy"){
            EnemyList.Remove(o.gameObject);
        }
    }

}
