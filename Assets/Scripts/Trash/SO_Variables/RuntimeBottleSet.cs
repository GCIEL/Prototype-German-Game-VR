using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCIEL.Toolkit;

[CreateAssetMenu]
public class RuntimeBottleSet : RuntimeSet<Trash> {
    // We can't have a generic runtime set that will work as we would wish in the Unity inspector,
    // so we have to create a RuntimeSet of a concrete type

    // Note that when we use the inspector to look at the contents of the runtime set while playing the game
    // we see "type mismatch", but the bottles are actually being stored there - the Unity inspector just doesn't
    // know how to display them in the items List

    Random rand;

    private void Awake()
    {
        base.OnEnable();
        rand = new Random();
    }

    public void ActivateRandomBottle()
    {
        int bottle = Random.Range(0, Items.Count - 1);
        Items[bottle].gameObject.SetActive(true);
    }
}
