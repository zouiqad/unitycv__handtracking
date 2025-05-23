using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HandTracker : MonoBehaviour
{
    public static HandTracker instance;

    public GameObject handCenterGO;

    [SerializeField] private UdpReceiver udpReceiver;
    private GameObject[] lmsGO;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        lmsGO = new GameObject[21];

        // Create points
        GameObject handGO = new GameObject("Hand");
        handGO.transform.position = new Vector3(20f, 2.0f, -10f);
        handGO.transform.Rotate(new Vector3(0.0f, 0.0f, -180.0f), Space.Self);


        for(int i = 0; i < lmsGO.Length; i++)
        {
            // Create a new GameObject
            lmsGO[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            lmsGO[i].AddComponent<LandmarkCollision>();
            lmsGO[i].GetComponent<Renderer>().material.color = Color.blue;
            lmsGO[i].name = $"lm{i}";
            lmsGO[i].transform.parent = handGO.transform;
        }


    }


    // Update is called once per frame
    void Update()
    {
        string message = udpReceiver.GetData();

        if(message != null)
        {
            // Remove brackets
            message = message.Remove(0, 1);
            message = message.Remove(message.Length - 1, 1);

            string[] points = message.Split(',');


            int pointIndex = 0;
            for (int i = 0; i < lmsGO.Length; i++)
            {
                float x = float.Parse(points[pointIndex++], System.Globalization.CultureInfo.InvariantCulture);
                float y = float.Parse(points[pointIndex++], System.Globalization.CultureInfo.InvariantCulture);
                float z = float.Parse(points[pointIndex++], System.Globalization.CultureInfo.InvariantCulture);

                lmsGO[i].transform.localPosition = new Vector3(x * 40.0f, z, y * 20.0f);
            }
            // assign ref to center hand
            handCenterGO = lmsGO[9];

        }


    }

    // for each sphere lm check if it is colliding 
    public GameObject CheckColision()
    {
        foreach(var lmGO in lmsGO)
        {
            LandmarkCollision collider = lmGO.GetComponent<LandmarkCollision>();
            if (collider.otherObject != null)
                return collider.otherObject;
        }

        return null;
    }
}
