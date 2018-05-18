using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCIEL.Toolkit;

public class OnStartGame : MonoBehaviour {

    public GameEvent OnStart;

	// Use this for initialization
	void Start () {
        OnStart.Raise();
        Debug.Log("Loaded Device Name: " + UnityEngine.XR.XRSettings.loadedDeviceName);
        Debug.Log("Model: " + UnityEngine.XR.XRDevice.model);
	}
	
}
