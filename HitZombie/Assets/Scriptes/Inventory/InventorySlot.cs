using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro.EditorUtilities;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;
    public GameObject iconGameObject;
    public TMP_Text itemAmount;

    private void Start()
    {
        iconGameObject = transform.GetChild(0).gameObject;
        itemAmount = transform.GetChild(1).GetComponent<TMP_Text>();
    }
    public void SetIcon(Sprite icon)
    {
        iconGameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGameObject.GetComponent<Image>().sprite = icon;
    }
}
