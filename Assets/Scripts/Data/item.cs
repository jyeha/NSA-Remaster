using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class item
{
    public int potion;
    public int potential_0;    
    public int potential_1;
    public int potential_2;
    public int potential_3;
    public int potential_4;
    public int potential_5;
    public int potential_6;
    public int potential_7;
    public int potential_8;
    public int potential_9;
    public int potential_10;
    public int potential_11;

    public void SetProperty(item _item){
        this.potion = _item.potion;
        this.potential_0 = _item.potential_0;
        this.potential_1 = _item.potential_1;
        this.potential_2 = _item.potential_2;
        this.potential_3 = _item.potential_3;
        this.potential_4 = _item.potential_4;
        this.potential_5 = _item.potential_5;
        this.potential_6 = _item.potential_6;
        this.potential_7 = _item.potential_7;
        this.potential_8 = _item.potential_8;
        this.potential_9 = _item.potential_9;
        this.potential_10 = _item.potential_10;
        this.potential_11 = _item.potential_11;
    }

    public void initItem(){
        potion = 0;
        potential_0 = 0;
        potential_1 = 0;
        potential_2 = 0;
        potential_3 = 0;
        potential_4 = 0;
        potential_5 = 0;
        potential_6 = 0;
        potential_7 = 0;
        potential_8 = 0;
        potential_9 = 0;
        potential_10 = 0;
        potential_11 = 0;
    }
}