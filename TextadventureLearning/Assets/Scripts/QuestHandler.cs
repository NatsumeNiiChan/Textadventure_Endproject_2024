using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestHandler : MonoBehaviour
{
    public bool HasQuestStarted;
    public bool QuestFinished;
    public int PanulaanQuestCount;
    public int PagsuyoQuestCount;
    public int HayopQuestCount;
    public int LupaQuestCount;
    public int TanimQuestCount;
    public int YariQuestCount;
    public int QuestCount;
    public bool GotPet;
    public int Lvl2Count;

    public int Plants;
    public bool GotBook;

    public DialogueManagement DialogueScript;
    private StandardMovement movementScript;

    private AudioSource sound;
    [SerializeField] private AudioClip doneSound;

    [SerializeField] private GameObject final;
    [SerializeField] private GameObject questUI;
    [SerializeField] private GameObject dialogueUI;
    //[SerializeField] public GameObject CharacterUI;
    [SerializeField] private bool levelOne;
    public bool LevelTwo;

    private void Awake()
    {
        sound = GameObject.Find("SoundHandler").GetComponent<AudioSource>();
        movementScript = FindObjectOfType<StandardMovement>();
    }

    private void Start()
    {
        final.SetActive(false);
    }

    private void Update()
    {
        if (PagsuyoQuestCount >= 5)
        {
            QuestCount++;
            PagsuyoQuestCount = 0;
            QuestFinished = true;
            sound.clip = doneSound;
            sound.Play();

            DialogueScript = GameObject.Find("Pagsuyo").GetComponentInChildren<DialogueManagement>();
            Debug.Log("Found");
            DialogueScript.TextTwo = false;
            DialogueScript.TextThree = true;
        }

        if (PanulaanQuestCount >= 10)
        {
            QuestCount++;
            PanulaanQuestCount = 0;
            QuestFinished = true;
            sound.clip = doneSound;
            sound.Play();
            GotBook = true;

            DialogueScript = GameObject.Find("Panulaan").GetComponentInChildren<DialogueManagement>();
            DialogueScript.TextTwo = false;
            DialogueScript.TextThree = true;
        }

        if (LupaQuestCount >= 6)
        {
            QuestCount++;
            LupaQuestCount = 0;
            QuestFinished = true;
            sound.clip = doneSound;
            sound.Play();

            DialogueScript = GameObject.Find("Lupa").GetComponentInChildren<DialogueManagement>();
            DialogueScript.TextTwo = false;
            DialogueScript.TextThree = true;
        }

        if (TanimQuestCount >= 2)
        {
            QuestCount++;
            TanimQuestCount = 0;
            QuestFinished = true;
            sound.clip = doneSound;
            sound.Play();

            DialogueScript = GameObject.Find("Tanim").GetComponentInChildren<DialogueManagement>();
            DialogueScript.TextTwo = false;
            DialogueScript.TextThree = true;
        }

        if (YariQuestCount >= 17)
        {
            QuestCount++;
            YariQuestCount = 0;
            QuestFinished = true;
            sound.clip = doneSound;
            sound.Play();

            DialogueScript = GameObject.Find("Yari").GetComponentInChildren<DialogueManagement>();
            DialogueScript.TextTwo = false;
            DialogueScript.TextThree = true;
        }

        if (QuestCount >= 6)
        {
            final.SetActive(true);

            if (final.GetComponentInChildren<DialogueManagement>().TextTwo == true)
            {
                movementScript.enabled = true;
                
                if (levelOne == true)
                {
                    SceneManager.LoadScene(2);
                }

                if (LevelTwo == true)
                {
                    SceneManager.LoadScene(3);
                }
            }

            else
            {
                return;
            }
        }

        //if (Lvl2Count >= 5)
        //{
        //    //questUI.SetActive(false);
        //    //Lvl2Count--;
        //    //QuestCount++;
        //    //CharacterUI.SetActive(true);
        //}
    }
}
