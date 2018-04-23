using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class BottleCollectionLogger : MonoBehaviour
{

    private StreamWriter writer;
    public TrashManager trashManager;
    
    private DateTime Appear;
    private DateTime Pickup;
    private DateTime Collect;
    private string Location;

    // Use this for initialization
    void Awake()
    {
        var dateString = string.Format("{0}-{1}-{2}-{3}-{4}-{5}", DateTime.Now.Year,
            DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        writer = File.AppendText("./Data/Bottles-" + dateString + ".txt");
        
        writer.WriteLine("Bottle, Location, Appear, Pickup, Collect"); 
    }

    public void BottleAppears()
    {
        Appear = DateTime.Now;
        Location = trashManager.getCurrentBottleLocation();
    }

    public void BottlePickedUp()
    {
        Pickup = DateTime.Now;
    }

    public void BottleCollected()
    {
        Collect = DateTime.Now;
        var logEntry = string.Format("{0}, {1}, {2}, {3}, {4}", trashManager.NumCollected - 1, Location,
            Appear, Pickup, Collect);
        writer.WriteLine(logEntry);
    }

    private void OnDestroy()
    {
        writer.Close();
    }
}