using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeerMove : MonoBehaviour
{
    private ObjectMove objectmove;
    private Transform target;
    private float damage;
    public GameObject motherTower;
    
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
        
        Collider2D[] hitsCol = Physics2D.OverlapCircleAll(o.transform.position, 3.0f);

        //Debug.Log(hitsCol);

        foreach(Collider2D hit in hitsCol){
            Debug.Log(hit.gameObject);
            if(hit.gameObject.tag == "Enemy")
                hit.gameObject.GetComponent<EnemyHP>().GetDamage(damage, motherTower);
        }
        Destroy(gameObject);
        
    }

}
