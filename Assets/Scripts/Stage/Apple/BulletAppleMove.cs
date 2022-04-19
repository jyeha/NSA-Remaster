using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAppleMove : MonoBehaviour
{
    private ObjectMove objectmove;
    private Transform target;
    [SerializeField]
    private float damage;
    [SerializeField]
    private GameObject motherTower;
    
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
        Destroy(gameObject);
        
    }

}
