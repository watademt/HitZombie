using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbalet : MonoBehaviour
{
    public float Tension;
    public bool _pressed = false;

    public Transform RopeTransform;

    public Vector3 RopeNearLocPos;
    public Vector3 RopeFarLocPos;

    public AnimationCurve RopeReturnAnim;

    public float ReturnTime; 
    public Bolt CurrentBolt;
    public float BoltSpeed;

    public Transform inventory;
    public GameObject message;
    private bool showMessage = false;
    void Start()
    {
        RopeNearLocPos = RopeTransform.localPosition;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < inventory.childCount; i++)
            {
                if(inventory.GetChild(i).GetComponent<InventorySlot>() == null)
                {
                    return;
                }
                if (inventory.GetChild(i).GetComponent<InventorySlot>().item.inHandName == "Arrow Variant")
                {
                    if(inventory.GetChild(i).GetComponent<InventorySlot>().amount <= 1)
                    {
                        showMessage = false;
                        _pressed = true;
                        CurrentBolt.SetToRope(RopeTransform);
                        inventory.GetChild(i).GetComponent<InventorySlot>().GetComponentInChildren<DragAndDropItem>().NullifySlotData();
                    }
                    else
                    {
                        showMessage = true;
                        _pressed = true;
                        CurrentBolt.SetToRope(RopeTransform);
                        inventory.GetChild(i).GetComponent<InventorySlot>().amount--;
                        inventory.GetChild(i).GetComponent<InventorySlot>().itemAmountText.text = inventory.GetChild(i).GetComponent<InventorySlot>().amount.ToString();
                    }

                }
            }
            if(showMessage == false)
            {
                SpawnMessage(message);
            }

        }
       
            
        
        if (Input.GetMouseButtonDown(0))
        {
            _pressed = false;
            StartCoroutine(RopeReturn());
            CurrentBolt.Shot(BoltSpeed*Tension);
            Tension = 0;
        }
        if (_pressed)
        {
            if (Tension < 1f)
            {
                Tension+=Time.deltaTime;
            }
            RopeTransform.localPosition = Vector3.Lerp(RopeNearLocPos, RopeFarLocPos, Tension);
        }
    }

    private void SpawnMessage(GameObject gameObject)
    {
        Instantiate(gameObject);
    }
    IEnumerator RopeReturn()
    {
        Vector3 startlocPos=RopeTransform.localPosition;
        for (float f=0; f < 1f; f += Time.deltaTime/ReturnTime)
        {
            RopeTransform.localPosition=Vector3.LerpUnclamped(startlocPos, RopeNearLocPos, RopeReturnAnim.Evaluate(f));
            yield return null;
        }
        RopeTransform.localPosition = RopeNearLocPos;
    }
}
