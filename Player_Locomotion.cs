using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Locomotion : MonoBehaviour
{
    Vector2 inputVector;
    Vector3 motionVector;
    public Camera playerCam;
    public float speed;
    Vector3 direction;
    Vector3 movement;
    Vector3 cameraForward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        inputVector = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (inputVector.x > 0.1f && inputVector.y > 0.1f)
        {
            motionVector = new Vector3(inputVector.x, 0, inputVector.y);
            cameraForward = new Vector3(playerCam.transform.forward.x,0,playerCam.transform.forward.z);
            direction = motionVector + cameraForward;
            movement = direction * speed * Time.deltaTime;
            transform.position = transform.position + movement;
        }
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }
}
