using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCIEL.Toolkit;

public class OnStartGame : MonoBehaviour {

    public GameEvent OnStart;

	// Use this for initialization
	void Start () {
        OnStart.Raise();
	}
	
}
