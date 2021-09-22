using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserClass
{
    public int ID;
    public string name;
    public int level;
    public int exp;
    public int gold;
    public int crystal;
    public int jewel;
    public OperatorClass assistant;
    public List<OperatorClass> own_op_list;
    public List<DeckClass> deck_list;
    public int map_clear;

    public void SetProperty(UserClass user){
        this.ID = user.ID;
        this.name = user.name;
        this.level = user.level;
        this.exp = user.exp;
        this.gold = user.gold;
        this.crystal = user.crystal;
        this.jewel = user.jewel;
        this.assistant = user.assistant;
        this.own_op_list = user.own_op_list;
        this.deck_list = user.deck_list;
        this.map_clear = user.map_clear;
    }

    public void initUser(){
        List<OperatorClass> temp = new List<OperatorClass>();
        this.ID = -1;
        this.name = "null";
        this.level = 1;
        this.exp = 0;
        this.gold = 0;
        this.crystal = 0;
        this.jewel = 0;
        //this.assistant = 1;
        this.own_op_list = temp;
        this.map_clear = 0;
    }
}