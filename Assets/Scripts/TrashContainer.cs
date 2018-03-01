using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCIEL.Toolkit;
using UnityEngine.UI;

public class TrashContainer : MonoBehaviour {

    [Tooltip("Type of tash the container accepts")]
    public TrashType type;

    [Tooltip("Pieces of trash of the given type collected")]
    public IntReference collected;

    [Tooltip("Text to fill in with the number of variables collected.")]
    public Text Label;

    // Use this for initialization
    void Start()
    {
        collected.Variable.SetValue(0);
        if (Label != null)
            Label.text = collected.Value.ToString() + " " + type.Title + " collected.";
    }

    private void OnTriggerEnter(Collider other)
    {

        Trash e = other.gameObject.GetComponent<Trash>();
        if (e != null)
        {

            if (e.type.Equals(type))
            {
                Destroy(other.gameObject); // TODO: Doesn't properly detach object from hand. 
                collected.Variable.ApplyChange(1);
                if (Label != null)
                    Label.text = collected.Value.ToString() + " " + type.Title + " collected.";
            }
        }
    }

    private void Update()
    {
        Label.transform.LookAt(Camera.main.transform);
        Label.transform.Rotate(0, 180, 0);
    }
}

