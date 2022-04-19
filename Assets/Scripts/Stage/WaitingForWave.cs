using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForWave : MonoBehaviour
{
    public bool isWaiting;
    public GameObject WaitingGuide;
    
    [SerializeField]
    private EnemySpawner enemySpawner;
    [SerializeField]
    private StageClearFail stageClearFail;

    // Start is called before the first frame update
    void Start()
    {
        isWaiting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemySpawner.enemyCount == 0){
            if(enemySpawner.CurrentWave.maxEnemyCount == enemySpawner.KillorArrivedEnemyCount){
                isWaiting = true;
            }
        }
        if(isWaiting){
            WaitingGuide.SetActive(true);
        }
        else if(!isWaiting){
            WaitingGuide.SetActive(false);
        }
    }
}
