using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GCIEL.Toolkit;
using UnityEngine.XR;

/***
 * Toggles between text based on which device the user is using
 * TODO: Generalize code as necessary
 ***/
public class DeviceToggle : MonoBehaviour
{

    private Text textbox;
    public StringReference RiftText;
    public StringReference ViveText;

    // Use this for initialization
    void Start()
    {
        textbox = GetComponent<Text>();
        if(XRDevice.isPresent)
        {
            if(XRDevice.model.Contains("Rift"))
            {
                textbox.text = RiftText.Value;
            }
            else
            {
                textbox.text = ViveText.Value;
            }
        }
    }
    
}
