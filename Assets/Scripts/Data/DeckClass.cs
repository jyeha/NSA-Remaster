using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeckClass
{
    public string deck_name;
    public List<OperatorClass> deck_member;
    public void SetProperty(DeckClass deck){
        this.deck_name = deck.deck_name;
        this.deck_member = deck.deck_member;
    }
}