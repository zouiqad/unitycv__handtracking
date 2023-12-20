using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BombSpawner bombSpawner;
    private Canvas canvas;

    public int life = 3;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        bombSpawner = GameObject.Find("BombSpawner").GetComponent<BombSpawner>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (life)
        {
            case 3:
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                canvas.transform.GetChild(1).gameObject.SetActive(true);
                canvas.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 2:
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                canvas.transform.GetChild(1).gameObject.SetActive(true);
                canvas.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                canvas.transform.GetChild(1).gameObject.SetActive(false);
                canvas.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 0:
                canvas.transform.GetChild(0).gameObject.SetActive(false);
                canvas.transform.GetChild(1).gameObject.SetActive(false);
                canvas.transform.GetChild(2).gameObject.SetActive(false);
                canvas.transform.GetChild(3).gameObject.SetActive(true);
                // Game Over
                Time.timeScale = 0;

                break;
        }

        // Update Score on text mesh pro
        canvas.transform.GetChild(4).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();

    }
}
