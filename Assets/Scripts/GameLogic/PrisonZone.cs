using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonZone : MonoBehaviour
{
    [SerializeField] public ColorEnum.Color prisonColor;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
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
                if (!bomb.secured) gameManager.score++;
                bomb.secured = true;
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
