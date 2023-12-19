using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureDetection : MonoBehaviour
{

    public UdpReceiver udpReceiver;


    public enum GestureType
    {
        Open_Palm,
        Closed_Fist
    }

    private int _currentGesture;
    private int CurrentGesture
    {
        get => _currentGesture;
        set
        {
            if (_currentGesture != value)
            {
                _currentGesture = value;
                OnGestureChanged?.Invoke(_currentGesture);
            }
        }
    }
    
    public delegate void GestureChangeHandler(int newGesture);
    public event GestureChangeHandler OnGestureChanged;

    private void HandleGestureChange(int newGesture)
    {

        // React to the gesture change here
        Debug.Log("Gesture changed to: " + newGesture);
    }

    // Start is called before the first frame update
    void Start()
    {
        OnGestureChanged += HandleGestureChange;
    }

    // Update is called once per frame
    void Update()
    {
        string message = udpReceiver.GetData();

        if (message != null)
        {
            CurrentGesture = message == GestureType.Closed_Fist.ToString() ? 0 : 1;
        }


    }

    void OnDestroy()
    {
        OnGestureChanged -= HandleGestureChange;
    }


}
