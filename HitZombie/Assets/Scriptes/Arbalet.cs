using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbalet : MonoBehaviour
{
    public float Tension;
    public bool _pressed;

    public Transform RopeTransform;

    public Vector3 RopeNearLocPos;
    public Vector3 RopeFarLocPos;

    public AnimationCurve RopeReturnAnim;

    public float ReturnTime; 
    public Bolt CurrentBolt;
    private int BoltIndex = 0;
    public float BoltSpeed;

    public Bolt[] BoltPool;
    void Start()
    {
        RopeNearLocPos = RopeTransform.localPosition;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _pressed = true;
            BoltIndex++;
            if(BoltIndex >= BoltPool.Length)
            {
                BoltIndex = 0;
            }
            CurrentBolt = BoltPool[BoltIndex];
            CurrentBolt.SetToRope(RopeTransform);
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
