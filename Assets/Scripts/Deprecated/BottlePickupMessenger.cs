using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottlePickupMessenger : MonoBehaviour {

    public Text text;
    public Transform m_camera;
    public Canvas canvas;

    void Start () {
        StartCoroutine(DisplayMessage("Hello. Welcome to the bottle collector. Take a look around.", 5));
	}

    private void Update()
    {
        //transform.position = m_camera.transform.position;
        //transform.rotation = Quaternion.LookRotation(m_camera.forward);
    }

    private IEnumerator DisplayMessage(string msg, float warningDisplayTime) 
    {
        text.text = msg;
        //transform.rotation = Quaternion.LookRotation(m_camera.forward);
        //canvas.transform.rotation = Quaternion.LookRotation(m_camera.forward);
        //canvas.transform.position = m_camera.transform.position;
        // transform.position = m_camera.transform.position;

        yield return new WaitForSeconds(warningDisplayTime);

        // text.text = string.Empty;
    }

}
