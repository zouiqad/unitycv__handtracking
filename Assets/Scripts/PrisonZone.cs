using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonZone : MonoBehaviour
{
    [SerializeField] public ColorEnum.Color prisonColor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            Bomb bomb = other.gameObject.GetComponent<Bomb>();
            if (bomb.bombColor == prisonColor)
            {
                bomb.secured = true;
                bomb.Release();
                Debug.Log("Bomb is secured");
            }
            else
            {
                Debug.Log("Wrong color");
                bomb.Release();
                bomb.transform.position = Vector3.zero;
            }
        }
    }
    
}
