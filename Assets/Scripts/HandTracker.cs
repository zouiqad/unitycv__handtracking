using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HandTracker : MonoBehaviour
{
    [SerializeField] private UdpReceiver udpReceiver;

    private GameObject[] lmGO;
    // Start is called before the first frame update
    void Start()
    {
        lmGO = new GameObject[21];

        // Create points

        GameObject handGO = new GameObject("Hand");
        handGO.transform.position = new Vector3(-12.5f, 2.0f, 12.5f);
        handGO.transform.Rotate(new Vector3(-90.0f, 0.0f, 0.0f), Space.Self);


        for(int i = 0; i < lmGO.Length; i++)
        {
            // Create a new GameObject
            lmGO[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            lmGO[i].GetComponent<Renderer>().material.color = Color.blue;
            lmGO[i].name = $"lm{i}";
            lmGO[i].transform.parent = handGO.transform;
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
            for (int i = 0; i < lmGO.Length; i++)
            {
                float x = float.Parse(points[pointIndex++], System.Globalization.CultureInfo.InvariantCulture);
                float y = float.Parse(points[pointIndex++], System.Globalization.CultureInfo.InvariantCulture);
                float z = float.Parse(points[pointIndex++], System.Globalization.CultureInfo.InvariantCulture);

                lmGO[i].transform.localPosition = new Vector3(x * 20.0f, y * 20.0f, z * 20.0f);

            }
        }


    }
}
