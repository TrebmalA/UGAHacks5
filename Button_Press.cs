using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Press : MonoBehaviour
{
    public Material PressedMaterial;
    public Material buttonMat;
    public GameObject btnMngr;
    public AudioClip buttonSound;
    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(buttonSound, other.gameObject.transform.position);
        if(other.tag == "Button" || other.tag == "Active_Button")
        {
            btnMngr.GetComponent<Button_Manager>().incrementScore(other.gameObject);
            other.GetComponent<MeshRenderer>().material = buttonMat;
        }
        if(other.tag == "Start_Button")
        {
            btnMngr.GetComponent<Button_Manager>().startWhackAMole();
        }
    }
}
