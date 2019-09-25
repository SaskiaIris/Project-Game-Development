using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSlot : MonoBehaviour
{
    [SerializeField]
    private Color availableColor = Color.black, selectedColor = Color.black;

    private Material material;
    private TrapManager trapManager;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
        material.color = availableColor;
        trapManager = FindObjectOfType<TrapManager>();
    }

    private void OnMouseEnter()
    {
        material.color = selectedColor;
    }

    private void OnMouseExit()
    {
        material.color = availableColor;
    }

    private void OnMouseDown()
    {
        if (trapManager.selectingTrapSlot)
            trapManager.PlaceTrap(this);
    }
}
