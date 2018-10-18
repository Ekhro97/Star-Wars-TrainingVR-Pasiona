using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsCollision : MonoBehaviour {

    public GameObject particlePrefab;
    public GameObject sparkPrefab;

    private GameObject swordParticles;
    private GameObject sparkParticles;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Sword")
        {
            swordParticles = Instantiate(particlePrefab, collision.contacts[0].point, new Quaternion());
            sparkParticles = Instantiate(sparkPrefab, collision.contacts[0].point, new Quaternion());
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Sword")
        {
            OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.LTouch);

            swordParticles.transform.position = collision.contacts[0].point;
            sparkParticles.transform.position = collision.contacts[0].point;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Sword")
        {
            OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);

            Destroy(swordParticles);
            Destroy(sparkParticles);
        }
    }
}
