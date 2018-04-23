using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LocationLogger : MonoBehaviour {

    private StreamWriter writer;
    private float repeatTime = 1.0f; // Takes measurements every second

    // Use this for initialization
    void Awake () {
        var dateString = string.Format("{0}-{1}-{2}-{3}-{4}-{5}", DateTime.Now.Year,
            DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
         writer = File.AppendText("./Data/HMD-" + dateString + ".txt");
        writer.WriteLine("time, coordinate-x, coorindate-y, coordinate-z, euler-x, euler-y, euler-z");
        InvokeRepeating("LogPosition", 0.0f, repeatTime);
    }
	
	// Update is called once per frame
	void LogPosition () {
        Transform transform = gameObject.transform;
        string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        var logEntry = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", timestamp, 
            transform.position.x, transform.position.y, transform.position.z,
            transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        writer.WriteLine(logEntry);
    }

    private void OnDestroy()
    {
        writer.Close();
    }
}
