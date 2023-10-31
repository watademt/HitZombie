using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltTorque : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float VelocityMult;
    public float AngularVelocityMult;

    private void FixedUpdate()
    {
        Vector3 cross = Vector3.Cross(transform.right, Rigidbody.velocity.normalized);
        Rigidbody.AddForce(cross * Rigidbody.velocity.magnitude * VelocityMult);
        Rigidbody.AddTorque((-Rigidbody.angularVelocity + Vector3.Project(Rigidbody.angularVelocity, transform.right)) * Rigidbody.velocity.magnitude * AngularVelocityMult);
    }
}
