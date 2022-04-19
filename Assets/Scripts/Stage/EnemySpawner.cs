using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // [SerializeField]
    // private GameObject enemy;
    // [SerializeField]
    // private float spawnTime;
    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private GameObject enemyHPSlider;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private PlayerHP playerHP;
    [SerializeField]
    private Cost cost;
    private Wave currentWave;
    public int enemyCount;
    public int KillorArrivedEnemyCount;
    public Wave CurrentWave => currentWave;
    
    private void Start(){
        //StartCoroutine("EnemySpawn");
    }

    public void StartWave(Wave wave){
        currentWave = wave;
        StartCoroutine("EnemySpawn");
    }

    private IEnumerator EnemySpawn(){
        KillorArrivedEnemyCount = 0;
        enemyCount = 0;
        int spawnEnemyCount = 0;

        while(spawnEnemyCount < currentWave.maxEnemyCount){

            int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
            GameObject newEnemy = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
            Enemy _enemy = newEnemy.GetComponent<Enemy>();

            ShowEnemyHPSlider(newEnemy);

            spawnEnemyCount++;
            enemyCount++;

            _enemy.Setup(this, wayPoints);
            yield return new WaitForSeconds(currentWave.spawnTime);
        }
        
    }

    private void ShowEnemyHPSlider(GameObject newEnemy){
        GameObject sliderClone = Instantiate(enemyHPSlider);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<SliderPositionSetter>().Setup(newEnemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(newEnemy.GetComponent<EnemyHP>());
    }

    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy, int cost){
        if(type == EnemyDestroyType.Arrive)
            playerHP.PlayerGetDamage(1);
        else if(type == EnemyDestroyType.Kill)
            this.cost.CurrentCost += cost;
        Destroy(enemy.gameObject);
        enemyCount--;
        KillorArrivedEnemyCount++;
    }

}
