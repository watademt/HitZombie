using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    void Start()
    {
        for(int i = 0; i < inventoryPanel.childCount; i++)
        {
            if(inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        Inventory.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) 
        {
            isOpened = !isOpened;
            if(isOpened)
            {
                Inventory.SetActive(true);
            }
            else
            {
                Inventory.SetActive(false);
            }
        }
    }
}
