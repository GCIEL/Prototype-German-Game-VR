using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GCIEL.Toolkit;

public class BottlesCollectedDisplay : MonoBehaviour {

    [SerializeField]
    public List<TrashType> trashTypes;

    public void UpdateDisplay()
    {
        string displayText = "";

        foreach(TrashType type in trashTypes)
        {
            displayText += type.Title + ": " + type.CorrectCollectedItems + " out of " + type.TotalItems + " correct.\n";
        }

        gameObject.GetComponent<Text>().text = displayText;

    }
}
