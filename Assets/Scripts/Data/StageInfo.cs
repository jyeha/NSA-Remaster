using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour{
    public int stageNum;
    public int gainEXP;
    public int gainPotion;
    public int gainGold;
    public int gainCrystal;
    public bool isPerfectClear;

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
}