using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareMeter : MonoBehaviour
{
    public int scare;
    private RectTransform balkWidth;

    // Start is called before the first frame update
    void Start()
    {
        scare = 0;
        balkWidth = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scare <= 100)
        {
            balkWidth.sizeDelta = new Vector2(scare * 2, balkWidth.sizeDelta.y);
        }
    }
}