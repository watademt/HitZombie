using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public Rigidbody Rigidbody;

    public void SetToRope(Transform ropeTransform)
    {
        transform.parent = ropeTransform;
        transform.localPosition = new Vector3(0f,1f,0.388f);
        transform.localRotation = Quaternion.identity;

        Rigidbody.isKinematic = true;
    }
    public void Shot(float velocity)
    {
        transform.parent=null;
        Rigidbody.isKinematic = false;
        Rigidbody.velocity=transform.forward*velocity;
    }
}
