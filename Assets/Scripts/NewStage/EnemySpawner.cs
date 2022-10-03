/* 적을 스폰하고 삭제하는 스크립트 */
/* 웨이브 정보를 받아와서 적을 스폰하는 코루틴 실행 */
/* 적을 스폰 시 HP바가 함께 보이도록 */

/* spawnEnemyCount: 현재 웨이브 스폰된 적의 수 */
/* EnemyCount: 현재 맵에 존재하는 적의 수 */
/* KillorArrivedEnemyCount: 현재 웨이브에서 죽이거나 방어지점에 도착한 적의 수 */
using Assets.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField]
    //private Transform[] wayPoints;
    [SerializeField]
    private GameObject enemyHPSlider;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private PlayerHP playerHP;
    public int KillorArrivedEnemyCount;
    public Transform HPBarsTransform;

    [SerializeField] WaveSystem waveSystem;

    public GameObject enemyPrefab;

    // 웨이브 정보를 바탕으로 웨이브 시작: 적 스폰 시작
    private void StartWave(Wave wave)
    {
        StartCoroutine("EnemySpawn", wave);
    }

    private void Start()
    {
        waveSystem.StartWave += StartWave;
        //StartCoroutine("EnemySpawn", currentWave);
    }

    // 적을 스폰
    //private IEnumerator EnemySpawn(){
    //    KillorArrivedEnemyCount = 0;
    //    enemyCount = 0;
    //    int spawnEnemyCount = 0;

    //    while(spawnEnemyCount < currentWave.maxEnemyCount){

    //        int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
    //        GameObject newEnemy = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
    //        past_Enemy _enemy = newEnemy.GetComponent<past_Enemy>();

    //        ShowEnemyHPSlider(newEnemy);

    //        spawnEnemyCount++;
    //        enemyCount++;

    //        _enemy.Setup(this, wayPoints);
    //        yield return new WaitForSeconds(currentWave.spawnTime);
    //    }
        
    //}
    
    private IEnumerator EnemySpawn(Wave currentWave)
    {
        int spawnEnemyCount = 0;

        while(spawnEnemyCount < currentWave.maxEnemyCount)
        {
            GameObject newEnemy = Instantiate(enemyPrefab);
            Enemy _enemy = newEnemy.GetComponent<Enemy>();

            spawnEnemyCount++;

            _enemy.SetRoute(currentWave.wayPoints);

            yield return new WaitForSeconds(currentWave.spawnCycle);
        }
    }

    // 적의 체력바를 보여줌
    private void ShowEnemyHPSlider(GameObject newEnemy){
        GameObject sliderClone = Instantiate(enemyHPSlider);
        sliderClone.transform.SetParent(HPBarsTransform);
        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<SliderPositionSetter>().Setup(newEnemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(newEnemy.GetComponent<EnemyHP>());
    }

    // 적을 삭제
    public void DestroyEnemy(EnemyDestroyType type, past_Enemy enemy, int cost){
        if(type == EnemyDestroyType.Arrive)
            playerHP.PlayerGetDamage(1);
        Destroy(enemy.gameObject);
        KillorArrivedEnemyCount++;
    }

}
