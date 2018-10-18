using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtatchObject : MonoBehaviour {

    public GameObject gameobject;
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(gameobject.transform.position.x, gameobject.transform.position.y - 0.2f, gameobject.transform.position.z);
        transform.rotation = new Quaternion(gameobject.transform.rotation.x, gameobject.transform.rotation.y, gameobject.transform.rotation.z, gameobject.transform.rotation.w);
        transform.rotation *= Quaternion.Euler(40, 0, 0);
    }
}
