using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal Item", menuName = "Inventory/Items/New Heal Item")]
public class HealItem : ItemScriptabelObject
{
    public float healAmount;
    private void Start()
    {
        itemType = ItemType.Heal;
    }
}
