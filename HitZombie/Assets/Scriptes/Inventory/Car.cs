using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public Transform inventory;
    public Transform quickSlotInventory;
    public GameObject noFuelTank;
    public bool checkInventory;
    public bool checkQuickSlotInventory;

    public void CheckFuelTank()
    {
        for (int i = 0; i < inventory.childCount; ++i)
        {
            if (inventory.GetChild(i).GetComponent<InventorySlot>().item == null)
            {
                return;
            }
            if (inventory.GetChild(i).GetComponent<InventorySlot>().item.inHandName == "FuelTank")
            {
                SceneManager.LoadScene(2);
                break;
            }

        }
        for (int i = 0; i < quickSlotInventory.childCount; ++i)
        {
            if (quickSlotInventory.GetChild(i).GetComponent<InventorySlot>().item == null)
            {
                return;
            }
            if (quickSlotInventory.GetChild(i).GetComponent<InventorySlot>().item.inHandName == "FuelTank")
            {
                noFuelTank.SetActive(true);
                Invoke("NoFuelTank", 5.0f);
                break;
            }

        }
        void NoFuelTank()
        {
            noFuelTank.SetActive(false);
        }
    }
}