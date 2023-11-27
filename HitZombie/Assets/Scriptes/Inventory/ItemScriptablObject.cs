using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Heal, Weapon, Material}
public class ItemScriptabelObject : ScriptableObject
{
    public GameObject itemPrefab;
    public ItemType itemType;
    public string itemName;
    public int maxAmount;

}
