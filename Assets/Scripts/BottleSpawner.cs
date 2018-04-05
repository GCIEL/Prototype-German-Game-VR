using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCIEL.Toolkit;

public class BottleSpawner : MonoBehaviour {

    public Transform spawnTransform;
    public GameObject bottle;
    public float forwardScale;
    GameObject controllerModel;
    InteractionController interactionController;

    private SteamVR_TrackedObject trackedObj;
    public SteamVR_TrackedObject TrackedObj
    {
        get { return trackedObj; }
    }

    public SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        interactionController = GetComponent<InteractionController>();
    }

    void Update()
    {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            SpawnBottle();
        }
    }

    private void SpawnBottle()
    {
        // Make the spawn position be a bit higher than the spawnTransform so the bottle falls in front of player
        Vector3 heightAdjustedPosition = new Vector3(spawnTransform.position.x, spawnTransform.position.y + 1, spawnTransform.position.z);

        // Also adjust the position of the bottle so it appears in front of the CameraRig transform
        GameObject newBottle = Instantiate(bottle, heightAdjustedPosition + (spawnTransform.forward * forwardScale), spawnTransform.rotation);
        newBottle.AddComponent<SimpleGrab>();
    }
}
