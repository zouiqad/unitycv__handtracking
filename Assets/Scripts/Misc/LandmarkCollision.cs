using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkCollision : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    {
        print("collided with " + other.name);

    }

}
