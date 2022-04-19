using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{
    [SerializeField]
    private int currentCost = 100;

    public int CurrentCost{
        set => currentCost = Mathf.Max(0, value);
        get => currentCost;
    }
}
