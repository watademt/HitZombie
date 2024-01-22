using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIBG;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    public Camera mainCamera;
    public float reachDistance = 3f;
    public FirstPersonLook firstPersonLook;
    public GameObject hint;
    public bool checkHint;
    public GameObject carHint;
    public bool checkCarHint;
    public Car car;
    void Start()
    {
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIBG.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            isOpened = !isOpened;
            if (isOpened)
            {
                firstPersonLook.enabled = false;
                UIBG.SetActive(true);
                inventoryPanel.gameObject.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
        
            }
            else
            {
                firstPersonLook.enabled = true;
                UIBG.SetActive(false);
                inventoryPanel.gameObject.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (hit.collider.gameObject.GetComponent<Item>() != null)
            {
                hint.SetActive(true);
                checkHint = true;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject); 
                    hint.SetActive(false);
                    checkHint = false;
                }
            }
            else if (checkHint)
            {
                hint.SetActive(false);
                checkHint = false;
            }
            if (hit.collider.gameObject.GetComponent<Car>() != null)
            {
                carHint.SetActive(true);
                checkCarHint = true;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    car.CheckFuelTank();
                }
            }
            else if (checkCarHint)
            {
                carHint.SetActive(false);
                checkCarHint = false;
            }

        }
    }

    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.maxAmount)
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                break;
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
        }
    }
}
