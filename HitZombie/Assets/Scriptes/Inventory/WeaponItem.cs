using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Item", menuName = "Inventory/Items/New Weapon Item")]
public class WeaponItem : ItemScriptabelObject
{
    private void Start()
    {
        itemType = ItemType.Weapon;
    }
}
