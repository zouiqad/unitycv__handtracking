using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkCollision : MonoBehaviour
{
    public GameObject otherObject;

    private void OnTriggerEnter(Collider other)
    {
        print("collided with " + other.name);
        otherObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        print("exited collision with " + other.name);
        otherObject = null;
    }

}
