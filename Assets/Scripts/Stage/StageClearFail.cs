using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageClearFail : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject GameClearPanel;
    public GameObject WaitingGuide;
    public GameObject InformationPanel;
    public PlayerHP playerHP;
    public WaveSystem waveSystem;
    public EnemySpawner enemySpawner;
    GameObject gameManager;
    GameObject stageInformation;

    public bool isGameOver = false;
    public bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        stageInformation = GameObject.Find("StageInformation");
        isGameOver = false;
        isGameClear = false;
        GameOverPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHP.CurrentHP == 0){
            isGameOver = true;
            GameOverPanel.SetActive(true);
            WaitingGuide.SetActive(false);
            InformationPanel.SetActive(false);
        }
        
        if(waveSystem.AllWaveOver && enemySpawner.KillorArrivedEnemyCount == waveSystem.waves[waveSystem.MaxWave-1].maxEnemyCount){
            isGameClear = true;
            WaitingGuide.SetActive(false);
            InformationPanel.SetActive(false);
        }
        if(isGameOver && Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("StageSelectScene");
        }
        
        if(isGameClear){
            if(playerHP.CurrentHP == playerHP.MaxHP){
                stageInformation.GetComponent<StageInfo>().isPerfectClear = true;
            }
            else{
                stageInformation.GetComponent<StageInfo>().isPerfectClear = false;
            }
            GameClearPanel.SetActive(true);
            if(Input.GetMouseButtonDown(0)){
                SceneManager.LoadScene("StageResultScene");
            }
        }
    }
}
