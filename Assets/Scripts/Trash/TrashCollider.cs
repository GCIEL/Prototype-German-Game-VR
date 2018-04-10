using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCIEL.Toolkit;

public class TrashCollider : MonoBehaviour
{

    [Tooltip("Type of tash the container accepts")]
    private TrashType type;
    public IntReference points;

    [SerializeField]
    private GameEvent Collect;

    // -------------------------------------------------------------------

    private void Start()
    {
        type = GetComponentInParent<TrashContainer>().type;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        Trash e = go.GetComponent<Trash>();
        if (e != null)
        {
            // Update how many bottles have been collected, correctly or otherwise. 
            e.type.incrementCollectedItems();
            if (e.type == type)
            {
                points.Variable.ApplyChange(type.PointValue);
                e.type.incrementCorrectCollectedItems();
            }
            TrashContainer trashContainer = GetComponentInParent<TrashContainer>();
            trashContainer.UpdateLabel(e.type);

            Destroy(e);
            Collect.Raise();
        }
     }
}
