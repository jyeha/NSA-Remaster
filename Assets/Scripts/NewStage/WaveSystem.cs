/* 웨이브를 관리하는 스크립트 */

using Assets.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private Dictionary<float, List<Wave>> waves;
    private List<float> t;

    private int currentWaveIndex = -1;

    [SerializeField] private float time;

    public int CurrentWave => currentWaveIndex+1;
    public bool AllWaveOver = false;
    public Action<Wave> StartWave;

    [SerializeField] Wave www;
    int cnt = 0;

    private void Awake()
    {
        SetWaves();

        //foreach (var wave in waves)
        //{
        //    foreach (var item in wave.Value)
        //    {
        //        Debug.Log(wave.Key.ToString() + "초 " + "스폰주기: " + item.spawnCycle.ToString() + "스폰수: " + item.maxEnemyCount.ToString() + "적분류: " + item.enemyID.ToString());
        //    }
        //}
    }

    private void Start()
    {

    }
    
    private void Print()
    {
        Debug.Log(time);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(cnt == 0)
        {
            StartWave?.Invoke(www);
            cnt++;
        }
    }

    private void SetWaves()
    {
        waves = new Dictionary<float, List<Wave>>();
        GameObject route1 = GameObject.Find("Route01");
        GameObject route2 = GameObject.Find("Route02");
        Transform[] route01 = route1.GetComponentsInChildren<Transform>();
        Transform[] route02 = route2.GetComponentsInChildren<Transform>();
        
        List<Wave> wl1 = new List<Wave>();
        Wave w1 = new Wave(2.0f, 3, 1, route01);
        wl1.Add(w1);
        waves.Add(2.0f, wl1);

        List<Wave> wl2 = new List<Wave>();
        Wave w2 = new Wave(2.0f, 3, 1, route02);
        wl2.Add(w2);
        waves.Add(20.0f, wl2);

        List<Wave> wl3 = new List<Wave>();
        Wave w3 = new Wave(2.0f, 3, 2, route01);
        wl3.Add(w3);
        waves.Add(35.0f, wl3);

        List<Wave> wl4 = new List<Wave>();
        Wave w4 = new Wave(2.0f, 3, 2, route02);
        wl4.Add(w4);
        waves.Add(50.0f, wl4);

        List<Wave> wl5 = new List<Wave>();
        Wave w5 = new Wave(2.0f, 3, 3, route01);
        Wave w6 = new Wave(2.0f, 3, 3, route02);
        wl5.Add(w5);
        wl5.Add(w6);
        waves.Add(70.0f, wl5);
    }

    // 게임이 시작된 후 n초가 흐르면 해당하는 wave가 시작
    //public void StartWave(){
    //    if(enemySpawner.enemyCount == 0 && currentWaveIndex < waves.Length - 1){
    //        waitingForWave.isWaiting = false;
    //        currentWaveIndex++;
    //        enemySpawner.StartWave(waves[currentWaveIndex]);
    //        if(currentWaveIndex+1 == MaxWave)   AllWaveOver=true;
    //    }
    //}
}