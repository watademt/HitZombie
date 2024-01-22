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
    public GameObject end;

    public void CheckFuelTank()
    {
        ShowFuelTank(inventory);
        ShowFuelTank(quickSlotInventory);
    }
    private void ShowFuelTank(Transform inventory)
    {
        for (int i = 0; i < inventory.childCount; ++i)
        {
            if (inventory.GetChild(i).GetComponent<InventorySlot>().item == null)
            {
                continue;
            }
            if (inventory.GetChild(i).GetComponent<InventorySlot>().item.inHandName == "FuelTank")
            {
                end.SetActive(true);
                Invoke("LoadScene", 1f);
            }

        }
    }
    void LoadScene()
        {
            SceneManager.LoadScene(2);
        }
}