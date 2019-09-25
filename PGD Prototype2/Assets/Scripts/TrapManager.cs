using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapManager : MonoBehaviour
{
    [SerializeField] private Trap[] availableTraps = null;

    [SerializeField] private GameObject shopButtonGO = null, activatableButtonGO = null;
    [SerializeField] private GameObject buttonMenuGroup = null, activatableButtonGroup = null;
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject trapGO = null;
    [SerializeField] private GameObject[] trapSlots = null;
    public bool selectingTrapSlot { get; private set; }
    private Trap selectedTrap;
    
    private void Awake()
    {
        HideTrapSlots();
        CreateShopButtons();
    }

    private void CreateShopButtons()
    {
        foreach (Trap trap in availableTraps)
        {
            //create button and set its parent
            GameObject ButtonGO = Instantiate(shopButtonGO, buttonMenuGroup.transform);
            Button button = ButtonGO.GetComponent<Button>();

            //set button appearence
            button.GetComponentInChildren<Text>().text = trap.Name;
            button.GetComponent<Image>().sprite = trap.Icon;
            button.onClick.AddListener(() => SelectTrapSlot(trap));
        }
    }

    private void SelectTrapSlot(Trap trap)
    {
        ShowTrapsSlots();
        selectingTrapSlot = true;
        //storing the trap type of the button that was pressed
        selectedTrap = trap;
    }

    public void PlaceTrap(TrapSlot trapSlot)
    {
        //reading the trap type of the button that was pressed
        Trap trap = selectedTrap as SnakeTrap;

        //create the trap gameobject
        GameObject TrapGO = Instantiate(trapGO, trapSlot.transform.position, Quaternion.identity);

        //set trap position and target
        trap.Initialize(TrapGO.transform.position, player);

        trap.SetParticleSystem(TrapGO.GetComponentInChildren<ParticleSystem>());

        if (trap.IsActivatable)
        {
            //create button and set its parent
            GameObject ButtonGO = Instantiate(activatableButtonGO, activatableButtonGroup.transform);
            Button button = ButtonGO.GetComponent<Button>();

            //set button appearence
            button.GetComponentInChildren<Text>().text = trap.Name;
            button.GetComponent<Image>().sprite = trap.Icon;

            //make it so that the trap is triggered when the button is pressed
            button.onClick.AddListener(() => trap.TriggerTrap());
        }
        
        selectingTrapSlot = false;
        HideTrapSlots();
    }

    private void HideTrapSlots()
    {
        foreach (GameObject trapSlot in trapSlots)
        {
            trapSlot.SetActive(false);
        }
    }

    private void ShowTrapsSlots()
    {
        foreach (GameObject trapSlot in trapSlots)
        {
            trapSlot.SetActive(true);
        }
    }
}
