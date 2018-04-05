using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    public Transform origin;

    private void Start()
    {
        gameObject.transform.position = origin.position;   
    }

    public void move(Transform transform)
    {
        gameObject.transform.position = transform.position;
    }
}
