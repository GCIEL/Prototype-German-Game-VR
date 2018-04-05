using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using GCIEL.Toolkit;


public class Trash : SimpleGrab

{
    public TrashType type;
    
    public string location;
    [SerializeField]
    public List<GameEvent> OnCollectEvents;

    public override void Awake()
    {
        base.Awake();
        type.incrementTotalItems();
    }

    public void CollectAndDestroy()
    {
        foreach (GameEvent gameEvent in OnCollectEvents)
        {
            gameEvent.Raise();
        }
        Destroy(gameObject);
    }

}
