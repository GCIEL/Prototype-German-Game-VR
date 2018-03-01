using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TrashType : ScriptableObject {

    [SerializeField]
    private string title = "";

    public string Title
    {
        get { return title; }
    }
    
}
