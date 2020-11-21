using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUI : MonoBehaviour
{
    public void Show()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
    }
    public void Hide()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
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
