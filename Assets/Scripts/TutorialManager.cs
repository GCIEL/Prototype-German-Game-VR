using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    //private variable accessors
    private static TutorialManager _tutorialManagerInstance;
    public static TutorialManager Instance
    {
        get { return _tutorialManagerInstance ?? (_tutorialManagerInstance = new GameObject("TutorialManager").AddComponent<TutorialManager>()); }
    }

    private int _sphereCount = 0;
    public int SphereCount
    {
        get
        {
            return _sphereCount;
        }

        set
        {
            _sphereCount = _sphereCount + value;
            if(_sphereCount >= 3)
            {
                _doorOpen = true;
            }
        }
    }

    private bool _doorOpen = false;
    public bool DoorOpen
    {
        get
        {
            return _doorOpen;
        }
    }
}
