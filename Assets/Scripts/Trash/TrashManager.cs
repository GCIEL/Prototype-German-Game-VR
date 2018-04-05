using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCIEL.Toolkit;
using UnityEngine.UI;

public class TrashManager : MonoBehaviour
{
    public List<TrashType> trashTypes;

    public bool AllCollected
    {
        get
        {
            bool tally = true;
            foreach (TrashType type in trashTypes)
            {
                tally = tally && (type.TotalItems == type.CollectedItems);
            }
            return tally;
        }
    }

    /// <summary>
    /// Tallys the bottles collected
    /// </summary>
    public int NumCollected
    {
        get
        {
            int tally = 0;
            foreach (TrashType type in trashTypes)
            {
                tally += type.CollectedItems;
            }
            return tally;
        }
    }

    public GameEvent gameOver;

    [SerializeField]
    private List<GameObject> bottles;
    private GameObject currentBottle;

    [SerializeField]
    private Text bottleDirectionsDisplayText;

    public void Start()
    {
        // Randomize bottles here. We may want a Utils script.
        Utils.Shuffle<GameObject>(bottles, new System.Random());
        currentBottle = bottles[0];
        foreach(GameObject bottle in bottles)
        {
            bottle.SetActive(false); // Turns off all bottles after they have been counted.
        }
        currentBottle.SetActive(true);
        DisplayBottleLocation();
    }

    public void reset() { 
        
        foreach (TrashType type in trashTypes)
        {
            type.reset();
        }
        
    }

    public void CollectBottle()
    {
        if (AllCollected)
        {
            Debug.Log("You win!");
            gameOver.Raise();
        } else
        {
            currentBottle = bottles[NumCollected];
        }
    }

    public void RevealNextBottle()
    {
        currentBottle.SetActive(true);
    }

    public void DisplayBottleLocation()
    {
        bottleDirectionsDisplayText.text = "The next bottle is " + currentBottle.GetComponent<Trash>().location;
    }

    public void DisplayRecycleBottle()
    {
        bottleDirectionsDisplayText.text = "Recycle the bottle in the " + 
            currentBottle.GetComponent<Trash>().type.Title + 
            " recycling container.";
    }

    public void YouWin()
    {
        bottleDirectionsDisplayText.text = "You found all the bottles!";
    }
}

    
