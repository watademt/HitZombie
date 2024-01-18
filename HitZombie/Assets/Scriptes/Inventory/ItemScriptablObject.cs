using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Heal, Weapon, Material}
public class ItemScriptableObject : ScriptableObject
{
    public GameObject itemPrefab;
    public ItemType itemType;
    public string itemName;
    public int maxAmount;
    public Sprite icon;
    public bool isConsumable;
    public string inHandName;

    [Header("Consumable Characteristics")]
    public float changeHealth;
    public float changeBuff;

}
