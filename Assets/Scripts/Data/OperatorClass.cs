using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class OperatorClass
{
    public int op_code;
    public string name;
    public string rare;
    public int rank;
    public int level;
    public int attack;
    public int cost;
    public string img_name;
    public int weight;
    public string tempSDRoute;
    public string towerSDRoute;
 
    public void SetProperty(OperatorClass op){
        this.op_code = op.op_code;
        this.name = op.name;
        this.rare = op.rare;
        this.rank = op.rank;
        this.level = op.level;
        this.attack = op.attack;
        this.cost = op.cost;
        this.img_name = op.img_name;
        this.weight = op.weight;
        this.tempSDRoute = op.tempSDRoute;
        this.towerSDRoute = op.towerSDRoute;
    }
}
