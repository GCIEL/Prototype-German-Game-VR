﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrackCamera : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
