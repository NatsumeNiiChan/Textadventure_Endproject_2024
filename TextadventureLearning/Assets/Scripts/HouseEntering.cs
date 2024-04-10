using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEntering : MonoBehaviour
{
    public float XCoordinate;
    public float YCoordinate;

    [SerializeField] private bool inHouse;
    private GameObject interactText;
    private GameObject player;

    [SerializeField] private bool inTrigger;

    private void Awake()
    {
        interactText = GameObject.Find("InteractText");
        //interactText.SetActive(false);

        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (inTrigger == true & Input.GetKeyDown(KeyCode.Space))
        {
            player.transform.position = new Vector2(XCoordinate, YCoordinate);
            inTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
        interactText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
        interactText.SetActive(false);
    }
}
