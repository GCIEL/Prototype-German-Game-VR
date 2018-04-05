using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LogHandler : MonoBehaviour {

    private StreamWriter writer;

    private void Awake()
    {
        writer = File.AppendText("log.txt");
        DontDestroyOnLoad(gameObject);
        Application.logMessageReceived += HandleLog;
    }

    private void HandleLog(string condition, string stackTrace, LogType type)
    {
        var logEntry = string.Format("\n {0] {1} {2}", DateTime.Now, type, condition);
        writer.Write(logEntry);
    }

    private void OnDestroy()
    {
        writer.Close();
    }
}
