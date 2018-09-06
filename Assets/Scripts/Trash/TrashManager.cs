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

    /// <summary>
    /// Trash manager triggers the gameOver event when all bottles have been collected
    /// </summary>
    public GameEvent gameOver;


    /// <summary>
    /// List of all bottles (pieces of trash) in the game
    /// </summary>
    [SerializeField]
    private List<GameObject> bottles;
    private GameObject currentBottle;

    [SerializeField]
    private Text bottleDirectionsDisplayText;

    [SerializeField]
    private GameEvent TrashAppear;

    // -------------------------------------------------------------------
   
    /// <summary>
    /// Randomizes list of bottles and sets first as active
    /// </summary>
    public void Start()
    {

        // Resets counters for which trash has been collected
        reset();

        // Automatically gets all bottles from children
        foreach (Transform child in transform)
        {
            bottles.Add(child.gameObject);
        }

        Utils.Shuffle<GameObject>(bottles, new System.Random());
        currentBottle = bottles[0];
        foreach(GameObject bottle in bottles)
        {
            bottle.GetComponent<Trash>().type.incrementTotalItems();
            bottle.SetActive(false); // Turns off all bottles after they have been counted.
        }
        TrashAppear.Raise();
    }

    public void reset()
    { 
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
            DisplayYouWin();
            gameOver.Raise();
        }
        else
        {
            currentBottle = bottles[NumCollected];
        }
    }

    public void RevealNextBottle()
    {
        currentBottle.SetActive(true);
        bottleDirectionsDisplayText.text = "Die nächste Flasche ist " + currentBottle.GetComponent<Trash>().location;
    }

    public void DisplayRecycleBottle()
    {
        bottleDirectionsDisplayText.text = "Werfen Sie die Flasche in den Container für " + 
            currentBottle.GetComponent<Trash>().type.Title + 
            ".";
    }

    public void DisplayYouWin()
    {
        bottleDirectionsDisplayText.text = "You found all the bottles!";
    }

    public string getCurrentBottleLocation()
    {
        return currentBottle.GetComponent<Trash>().location;
    }
}

    
