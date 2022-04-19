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
    public item userItem;
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
        this.userItem = user.userItem;
        this.map_clear = user.map_clear;
    }

    public void initUser(){
        List<OperatorClass> OperatorTemp = new List<OperatorClass>();
        List<DeckClass> deckTemp = new List<DeckClass>();
        this.ID = -1;
        this.name = "null";
        this.level = 1;
        this.exp = 0;
        this.gold = 10000;
        this.crystal = 6000;
        this.jewel = 0;
        this.own_op_list = OperatorTemp;
        this.deck_list = deckTemp;
        this.userItem = new item();
        this.map_clear = 0;
    }
}