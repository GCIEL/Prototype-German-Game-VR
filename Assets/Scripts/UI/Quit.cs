using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using GCIEL.Toolkit;

public class Quit : InteractionObject {
   

    public override void OnTriggerWasPressed(InteractionController controller)
    {
        base.OnTriggerWasPressed(controller);
        Application.Quit();
    }
}
