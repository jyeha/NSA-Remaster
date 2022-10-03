using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP;
    [SerializeField]
    private Text hpText;
    [SerializeField]
    private Cost cost;
    [SerializeField]
    private Text costText;
    [SerializeField]
    private WaveSystem waveSystem;
    [SerializeField]
    private Text waveText;
    [SerializeField]
    private EnemySpawner enemySpawner;
    [SerializeField]
    private Text enemyText;
    [SerializeField]
    private TowerCount towerCount;
    public Text towerText;

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: " + playerHP.CurrentHP.ToString() + " / " + playerHP.MaxHP.ToString();

        costText.text = "Cost: " + cost.CurrentCost.ToString();

        //waveText.text = waveSystem.CurrentWave.ToString() + " / " + waveSystem.MaxWave.ToString();

        //enemyText.text = enemySpawner.KillorArrivedEnemyCount.ToString() + " / " + enemySpawner.CurrentWave.maxEnemyCount.ToString();

        towerText.text = "타워: " + towerCount.towerCount.ToString() + " / " + towerCount.MaxTowerCount.ToString();
    }
}
