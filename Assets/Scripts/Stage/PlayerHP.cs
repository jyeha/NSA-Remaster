using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float currentHP;
    [SerializeField]
    private float maxHP = 10;
    [SerializeField]
    private Image image;

    public float CurrentHP => currentHP;
    public float MaxHP => maxHP;
    // Start is called before the first frame update
    void Start()
    {
            currentHP = maxHP;
    }

    public void PlayerGetDamage(float damage){
        currentHP -= damage;

        StopCoroutine("PlayerHitAnimation");
        StartCoroutine("PlayerHitAnimation");

        if(currentHP <= 0){
            // stage failed
        }
    }

    IEnumerator PlayerHitAnimation(){
        Color color = image.color;
        color.a = 0.4f;
        image.color = color;

        while(color.a >= 0.0f){
            color.a -= Time.deltaTime;
            image.color = color;

            yield return null;
        }
        
    }
}
