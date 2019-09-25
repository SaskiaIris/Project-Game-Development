using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareMeter : MonoBehaviour
{
    public int scare;
    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        scare = 0;
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, scare * 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (scare <= 100)
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, scare * 5);
        }
    }
}