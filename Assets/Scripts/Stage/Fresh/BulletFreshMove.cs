using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletFreshMove : MonoBehaviour
{
    private ObjectMove objectmove;
    private Transform target;
    [SerializeField]
    private float damage;
    [SerializeField]
    private GameObject motherTower;
    private ObjectMove movement2D;
    
    public void BulletSetUp(GameObject obj){
        motherTower = obj;
        this.damage = motherTower.GetComponent<TowerInformation>().attack;
    }

    public void TargetSet(Transform tar){
        objectmove = GetComponent<ObjectMove>();
        target = tar;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null){
            Vector3 direction = (target.position - transform.position).normalized;
            objectmove.MoveTo(direction);
        }
        else{
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D o){
        if(!o.CompareTag("Enemy")) return;
        if(o.transform != target)   return;

        o.GetComponent<EnemyHP>().GetDamage(damage, motherTower.transform.Find("Collider").gameObject);

        float enemySpeed = o.gameObject.GetComponent<past_Enemy>().speed;

        movement2D = o.GetComponent<ObjectMove>();
        movement2D.MoveSpeed = 0.5f;
        StartCoroutine("TimeDelay");

    }

    IEnumerator TimeDelay(){
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a = 0.0f;
        gameObject.GetComponent<SpriteRenderer>().color = color;

        yield return new WaitForSeconds(1.0f);

        movement2D.ResetMoveSpeed();
        Destroy(gameObject);
    }
}
