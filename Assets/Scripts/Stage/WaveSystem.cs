using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public Wave[] waves;
    [SerializeField]
    private EnemySpawner enemySpawner;
    [SerializeField]
    private WaitingForWave waitingForWave;
    private int currentWaveIndex = -1;

    public int CurrentWave => currentWaveIndex+1;
    public int MaxWave => waves.Length;
    public bool AllWaveOver = false;

    public void StartWave(){
        if(enemySpawner.enemyCount == 0 && currentWaveIndex < waves.Length - 1){
            waitingForWave.isWaiting = false;
            currentWaveIndex++;
            enemySpawner.StartWave(waves[currentWaveIndex]);
            if(currentWaveIndex+1 == MaxWave)   AllWaveOver=true;
        }
    }
}

[System.Serializable]
public struct Wave{
    public float spawnTime;
    public int maxEnemyCount;
    public GameObject[] enemyPrefabs;
}