using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPViewer : MonoBehaviour
{
    private EnemyHP enemyHP;
    private Slider slider;

    // Start is called before the first frame update
    public void Setup(EnemyHP enemyHP)
    {
        this.enemyHP = enemyHP;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemyHP.CurrentHP / enemyHP.MaxHP;
    }
}
