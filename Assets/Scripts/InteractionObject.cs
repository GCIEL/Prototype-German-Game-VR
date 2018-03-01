using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    protected Transform cachedTransform; // 1
    [HideInInspector] // 2
    public InteractionController currentController; // 3

    public virtual void OnTriggerWasPressed(InteractionController controller)
    {
        currentController = controller;
    }

    public virtual void OnTriggerIsBeingPressed(InteractionController controller)
    {
    }

    public virtual void OnTriggerWasReleased(InteractionController controller)
    {
        currentController = null;
    }

    public virtual void Awake()
    {
        cachedTransform = transform; // 1
        if (!gameObject.CompareTag("InteractionObject")) // 2
        {
            Debug.LogWarning("This InteractionObject does not have the correct tag, setting it now.", gameObject); // 3
            gameObject.tag = "InteractionObject"; // 4
        }
    }

    public bool IsFree() // 1
    {
        return currentController == null;
    }

    public virtual void OnDestroy() // 2
    {
        if (currentController)
        {
            OnTriggerWasReleased(currentController);
        }
    }
}
