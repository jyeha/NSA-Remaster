/* ���� �����ϰ� �����ϴ� ��ũ��Ʈ */
/* ���̺� ������ �޾ƿͼ� ���� �����ϴ� �ڷ�ƾ ���� */
/* ���� ���� �� HP�ٰ� �Բ� ���̵��� */

/* spawnEnemyCount: ���� ���̺� ������ ���� �� */
/* EnemyCount: ���� �ʿ� �����ϴ� ���� �� */
/* KillorArrivedEnemyCount: ���� ���̺꿡�� ���̰ų� ��������� ������ ���� �� */
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

    // ���̺� ������ �������� ���̺� ����: �� ���� ����
    private void StartWave(Wave wave)
    {
        StartCoroutine("EnemySpawn", wave);
    }

    private void Start()
    {
        waveSystem.StartWave += StartWave;
        //StartCoroutine("EnemySpawn", currentWave);
    }

    // ���� ����
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

    // ���� ü�¹ٸ� ������
    private void ShowEnemyHPSlider(GameObject newEnemy){
        GameObject sliderClone = Instantiate(enemyHPSlider);
        sliderClone.transform.SetParent(HPBarsTransform);
        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<SliderPositionSetter>().Setup(newEnemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(newEnemy.GetComponent<EnemyHP>());
    }

    // ���� ����
    public void DestroyEnemy(EnemyDestroyType type, past_Enemy enemy, int cost){
        if(type == EnemyDestroyType.Arrive)
            playerHP.PlayerGetDamage(1);
        Destroy(enemy.gameObject);
        KillorArrivedEnemyCount++;
    }

}
