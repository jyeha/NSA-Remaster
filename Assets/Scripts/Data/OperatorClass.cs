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

    public void SetProperty(OperatorClass op){
        op_code = op.op_code;
        name = op.name;
        rare = op.rare;
        rank = op.rank;
        level = op.level;
        attack = op.attack;
        cost = op.cost;
        img_name = op.img_name;
    }
}
