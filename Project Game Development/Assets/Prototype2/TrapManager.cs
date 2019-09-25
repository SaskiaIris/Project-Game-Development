using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapManager : MonoBehaviour
{
    [SerializeField] private Trap trap = null;

    [SerializeField] private Button button = null;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject[] trapSlots = null;

    private Vector3[] trapPositions;

    private void Awake()
    {
        trap.Initialize(player.transform.position, player);
        button.onClick.AddListener(() => trap.TriggerTrap());
        /*
        foreach(Trap trap in traps)
        {
            if(trap.Activatable)
            {
                button[i].onClick.AddListener(() => trap.TriggerTrap());
                button[i].GetComponentInChildren<Text>().text = trap.Name;
                button[i].GetComponent<Image>().sprite = trap.Icon;
            }
        }
        */
        
        trapPositions = new Vector3[trapSlots.Length];
    }
}
