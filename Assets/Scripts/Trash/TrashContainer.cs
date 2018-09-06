using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCIEL.Toolkit;
using UnityEngine.UI;

public class TrashContainer : MonoBehaviour {

    [Tooltip("Type of trash the container accepts")]
    public TrashType type;

    [Tooltip("Text to fill in with the number of variables collected.")]
    private Canvas Label;

    /// <summary>
    /// Displays feedback for the user about whether or not they put trash in 
    /// the correct container
    /// </summary>
    private GameObject titleCanvas;

    // -------------------------------------------------------------------

    private void Start()
    {
        Label = GetComponentInChildren<Canvas>();
        titleCanvas = Label.gameObject;

        titleCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Label.isActiveAndEnabled)
        {
            Label.transform.LookAt(Camera.main.transform);
            Label.transform.Rotate(0, 180, 0);
        }
    }

    public void UpdateLabel(TrashType givenBottleType)
    {
        StartCoroutine(DisplayFeedback(givenBottleType));
    }

    public IEnumerator DisplayFeedback(TrashType givenBottleType)
    {
        titleCanvas.SetActive(true);

        if (givenBottleType == type && Label != null)
        {
            Label.GetComponentInChildren<Text>().text = "Richtig!";
        }
        else
        {
            Label.GetComponentInChildren<Text>().text = "Falsch!";
        }

        yield return new WaitForSeconds(5.0f);
        titleCanvas.SetActive(false);
    }
}

