using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //[SerializeField] private GameObject uiObject;
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
                taskMScript.BookCount++;
            }

            if (isDrum == true)
            {
                taskMScript.DrumCount++;
            }

            sound.clip = clip;
            sound.Play();
            Destroy(gameObject);
        }
    }
}
