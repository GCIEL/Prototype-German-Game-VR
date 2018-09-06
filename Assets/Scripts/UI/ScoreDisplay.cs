using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GCIEL.Toolkit;

public class ScoreDisplay : MonoBehaviour {

    public IntReference score;

	public void UpdateScore()
    {
        gameObject.GetComponent<Text>().text = "Punkte: " + score.Value;
    }
}
