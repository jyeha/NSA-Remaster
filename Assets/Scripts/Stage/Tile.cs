using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool IsBuild { set; get; }

    void Start(){
        IsBuild = false;
    }
}
