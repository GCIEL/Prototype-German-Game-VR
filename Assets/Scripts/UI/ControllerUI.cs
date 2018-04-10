﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUI : MonoBehaviour {

    private Canvas canvas;

    private SteamVR_TrackedObject trackedObj;
    public SteamVR_TrackedObject TrackedObj
    {
        get { return trackedObj; }
    }

    public SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // Use this for initialization
    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        canvas = GetComponentInChildren<Canvas>();
        canvas.GetComponent<CanvasRenderer>().SetColor(Color.white);
        canvas.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
        
            canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
        }

        canvas.transform.LookAt(Camera.main.transform, Vector3.up);
        canvas.transform.Rotate(0, 180, 0);

    }
}
