using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsCollision : MonoBehaviour {

    public GameObject particlePrefab;
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.collider.gameObject.tag == "Right" || collision.collider.gameObject.tag == "Left")
    //    {
    //        OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.RTouch);
    //        OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.LTouch);
    //    }

    //    Instantiate(particlePrefab, collision.contacts[0].point, new Quaternion());
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Right" || collision.collider.gameObject.tag == "Left")
        {
            OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.LTouch);

            Debug.Log("test");
            Instantiate(particlePrefab, collision.contacts[0].point, new Quaternion());

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Right" || collision.collider.gameObject.tag == "Left")
        {
            OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Right" || other.gameObject.tag == "Left")
        {
            OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.LTouch);

            Debug.Log("test");
            //Instantiate(particlePrefab, collision.contacts[0].point, new Quaternion());

        }
    }
}
