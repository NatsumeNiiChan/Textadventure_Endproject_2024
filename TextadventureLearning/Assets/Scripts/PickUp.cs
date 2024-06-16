using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    //[SerializeField] private GameObject uiObject;
    [SerializeField] private GameObject helpUI;
    [SerializeField] private Image runeUI;
    [SerializeField] private string textUI;
    [SerializeField] private Sprite infoImage;
    [SerializeField] private string infoText;
    public bool IsPickable;
    private TaskManager taskMScript;
    public bool isSpaceable;

    [SerializeField] private bool isBook;
    [SerializeField] private bool isDrum;

    [SerializeField] private AudioClip clip;
    private AudioSource sound;

    private void Awake()
    {
        taskMScript = FindObjectOfType<TaskManager>();
        sound = GameObject.Find("SoundHandler").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (IsPickable == true && Input.GetKeyDown(KeyCode.Space))
        {
            //uiObject.SetActive(false);
            if (isBook == true)
            {
                helpUI.GetComponentInChildren<TMP_Text>().text = textUI;
                runeUI.sprite = infoImage;
                helpUI.SetActive(true);
                taskMScript.BookCount++;
            }

            if (isDrum == true)
            {
                taskMScript.DrumCount++;
            }

            sound.clip = clip;
            sound.Play();
            Invoke("EndUI", 2f);
        }
    }

    private void EndUI()
    {
        helpUI.SetActive(false);
        Destroy(gameObject);
    }
}
