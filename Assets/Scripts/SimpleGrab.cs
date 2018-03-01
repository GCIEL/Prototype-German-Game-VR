using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SimpleGrab : InteractionObject {

    public bool hideControllerModelOnGrab; // 1
    private Rigidbody rb; // 2
    private FixedJoint fj;

    public override void Awake()
    {
        base.Awake(); // 1
        rb = GetComponent<Rigidbody>(); // 2
    }

    private void AddFixedJointToController(InteractionController controller) // 1
    {
        FixedJoint fx = controller.gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 1500;
        // fx.breakTorque = 20000;
        fx.connectedBody = rb;
    }

    private void RemoveFixedJointFromController(InteractionController controller) // 2
    {
        if (controller.gameObject.GetComponent<FixedJoint>())
        {
            FixedJoint fx = controller.gameObject.GetComponent<FixedJoint>();
            fx.connectedBody = null;
            Destroy(fx);
        }
    }

    //private void AddFixedJoint(RWVR_InteractionController controller)
    //{
    //    fj = gameObject.AddComponent<FixedJoint>();
    //    fj.breakForce = 1500f;
    //    fj.connectedBody = controller.GetComponent<Rigidbody>();
    //}

    //private void RemoveFixedJoint()
    //{
    //    fj.connectedBody = null;
    //    Destroy(fj);
    //}

    //private void RemoveFixedJointFromController(RWVR_InteractionController controller) // 2
    //{
    //    if (controller.gameObject.GetComponent<FixedJoint>())
    //    {
    //        Debug.Log("Removing FJ");
    //        FixedJoint fx = controller.gameObject.GetComponent<FixedJoint>();
    //        fx.connectedBody = null;
    //        Destroy(fx);
    //    } else
    //    {
    //        Debug.LogError("Tried to remove fixedJoint from Controller but none was found.");
    //    }
    //}

    public override void OnTriggerWasPressed(InteractionController controller) // 1
    {
        base.OnTriggerWasPressed(controller); // 2

        if (hideControllerModelOnGrab) // 3
        {
            controller.HideControllerModel();
        }

        controller.Vibrate(800);
        AddFixedJointToController(controller); // 4
    }

    public override void OnTriggerWasReleased(InteractionController controller) // 1
    {
        base.OnTriggerWasReleased(controller); //2

        if (hideControllerModelOnGrab) // 3
        {
            controller.ShowControllerModel();
        }

        rb.velocity = controller.velocity; // 4
        rb.angularVelocity = controller.angularVelocity;

        RemoveFixedJointFromController(controller); // 5
    }

    //public override void OnTriggerWasReleased(RWVR_InteractionController controller) // 1
    //{
    //    base.OnTriggerWasReleased(controller); //2

    //    if (hideControllerModelOnGrab) // 3
    //    {
    //        controller.ShowControllerModel();
    //    }

    //    Transform origin = controller.TrackedObj.origin;

    //    if (origin)
    //    {
    //        rb.velocity = origin.TransformDirection(controller.velocity); // Why do I have to make this * -1?
    //        rb.angularVelocity = origin.TransformDirection(controller.angularVelocity);
    //    } else
    //    {
    //        rb.velocity = controller.velocity;
    //        rb.angularVelocity = controller.angularVelocity;
    //    }

    //    RemoveFixedJointFromController(controller);
    //}
}
