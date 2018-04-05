using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using GCIEL.Toolkit;


public class Trash : SimpleGrab
{
    public TrashType type;

    /// <summary>
    /// Where the piece of trash is located in the scene
    /// </summary>
    public string location;
    
}
