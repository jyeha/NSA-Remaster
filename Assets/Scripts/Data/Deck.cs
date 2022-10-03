using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected List<Tower> _members;

    public string Name { get { return _name; } set { _name = value; } }
    public List<Tower> Members { get { return _members; } set { _members = value; } }

}
