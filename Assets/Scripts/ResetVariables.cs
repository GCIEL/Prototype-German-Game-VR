using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCIEL.Toolkit;



public class ResetVariables : MonoBehaviour {

    public IntReference points;

	// Use this for initialization
	void Start () {
        points.Variable.SetValue(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
