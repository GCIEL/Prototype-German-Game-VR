using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TrashType : ScriptableObject {

    // Todo:  Properly hide variables

    [SerializeField]
    private string title = "";

    
    public int TotalItems;
    public int CollectedItems;
    public int CorrectCollectedItems;
    public int PointValue;

    public string Title
    {
        get { return title; }
    }

    public void incrementTotalItems()
    {
        TotalItems++;
    }

    public void incrementCollectedItems()
    {
        CollectedItems++;
    }

    public void incrementCorrectCollectedItems()
    {
        CorrectCollectedItems++;
    }

    private void OnEnable()
    {
        Debug.Log("Enabled");
        reset();
    }

    public void reset()
    {
        Debug.Log("reset");
        CollectedItems = 0;
        TotalItems = 0;
        CorrectCollectedItems = 0;
    }
    
}
