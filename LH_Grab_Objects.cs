using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LH_Grab_Objects : MonoBehaviour
{
    private Rigidbody attachedRigidBody = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (attachedRigidBody != null)
        {
            if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.LHandTrigger))
            {
                Vector3 difference = attachedRigidBody.position - this.transform.position;
                attachedRigidBody.velocity = -difference / Time.fixedDeltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRB = other.attachedRigidbody;
        
        if(otherRB == null || other.gameObject.tag!="Grabbable")
        {
            return;
        }
        attachedRigidBody = otherRB;
        Debug.Log("Attached to " + otherRB);
    }

    private void OnTriggerExit(Collider other)
    {
        attachedRigidBody = null;
    }
}
