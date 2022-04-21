using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 40.0f;
    private Transform targetTransform;
    private RectTransform rectTransform;

    
    public void Setup(Transform target)
    {
        targetTransform = target;
        rectTransform = GetComponent<RectTransform>();

    }   

    // Update is called once per frame
    private void LateUpdate()
    {   
        if(targetTransform == null){
            Destroy(gameObject);
            return;
        }

        Vector3 screenposition = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenposition + distance;
    }
}
