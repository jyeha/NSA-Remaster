using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfoSave : MonoBehaviour
{
    public int StageNum;

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
