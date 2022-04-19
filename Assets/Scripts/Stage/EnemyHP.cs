using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP, currentHP;
    private bool isDie = false;
    private Enemy enemy;
    private SpriteRenderer spriteRenderer;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void GetDamage(float damage, GameObject tower){
        if(isDie) return;

        currentHP -= damage;

        StopCoroutine("HitAnimation");
        StartCoroutine("HitAnimation");

        if(currentHP <= 0){
            isDie = true;
            if(tower.GetComponent<TowerAppleAttack>() != null)
                tower.GetComponent<TowerAppleAttack>().EnemyList.Remove(gameObject);
            else if(tower.GetComponent<TowerBeerAttack>() != null)
                tower.GetComponent<TowerBeerAttack>().EnemyList.Remove(gameObject);
            enemy.OnDie(EnemyDestroyType.Kill);
        }
    }

    private IEnumerator HitAnimation(){
        Color color = spriteRenderer.color;
        spriteRenderer.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = color;
    }
}
