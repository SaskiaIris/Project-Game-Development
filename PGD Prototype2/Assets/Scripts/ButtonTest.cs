using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    int puntenAantal;
    public Text puntText;


    // Start is called before the first frame update
    void Start()
    {
        puntenAantal = 100;
        setPuntenText();
    }

    public void Click()
    {
        puntenAantal -= 5;
        Debug.Log(puntenAantal);
        setPuntenText();
    }

    public void setPuntenText()
    {
        puntText.text = "Punten: " + puntenAantal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
