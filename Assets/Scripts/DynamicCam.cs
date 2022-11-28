using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCam : MonoBehaviour
{
    public GameObject cam2;


    // controle da camera
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "CamTrigger":
                cam2.SetActive(true);
                break;
        }

    }

    // controle da camera
    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "CamTrigger":
                cam2.SetActive(false);
                break;
        }

    }
}
