using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCIEL.Toolkit;
using UnityEngine.UI;

public class BottleSequencer : MonoBehaviour {

    /// <summary>
    /// The list of bottles to be collected in the desired order for collection.
    /// Does not include the bottle provided for the player at game start
    /// because this bottle is already active at game start.
    /// </summary>
    [SerializeField]
    private List<GameObject> bottles;

    [SerializeField]
    private GameEvent trashCollected;

    [SerializeField]
    private Text bottleDirectionsDisplayText;

    /// <summary>
    /// These GameObjects are used to find the closest landmark to a bottle, 
    /// so that we can generate text to guide the user to the bottle's location.
    /// </summary>
    [SerializeField]
    private List<GameObject> landmarks;

    private int bottlesCollected;

    public void RevealNextBottle()
    {
        Debug.Assert(bottlesCollected < bottles.Count);

        bottles[bottlesCollected].SetActive(true);
        bottlesCollected++;
    }

    /// <summary>
    /// Locates the landmark nearest to the bottle that user currently has to search for.
    /// </summary>
    /// <returns>The name of the landmark</returns>
    public string GetNearestBottleLandmark()
    {
        if (bottlesCollected >= bottles.Count)
        {
            Debug.LogError("Improper bottle list or no bottle to collect");
        }

        GameObject curBottle = bottles[bottlesCollected];
        Vector3 bottlePos = curBottle.transform.position;

        float minDistance = float.MaxValue;
        string closestLandmarkName = "";
        float landmarkDistance;

        foreach (var landmark in landmarks)
        {
            landmarkDistance = Vector3.Distance(bottlePos, landmark.transform.position);
            if (landmarkDistance < minDistance)
            {
                minDistance = landmarkDistance;
                closestLandmarkName = landmark.name; 
                // TODO: Make some more language-agnostic / punctuation agnostic scheme for returning a good landmark name
                // Idea: Just play audio corresponding to the landmark location and make text available on your controller UI.
            }
        }

        return closestLandmarkName;
    }

    public void UpdateBottleDirections()
    {
        string directions = "The next bottle is near the ";
        bottleDirectionsDisplayText.text = directions + GetNearestBottleLandmark() + ".";
    }
}
