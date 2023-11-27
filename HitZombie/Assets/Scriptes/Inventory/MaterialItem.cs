using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Material Item", menuName = "Inventory/Items/New Material Item")]
public class MaterialItem : ItemScriptabelObject
{
    private void Start()
    {
        itemType = ItemType.Material;
    }
}
