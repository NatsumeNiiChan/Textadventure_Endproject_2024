using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManagement : MonoBehaviour
{
    public string[] LinesOne;
    public string[] LinesTwo;
    public string[] LinesThree;
    public float TextSpeed;

    private GameObject textBox;
    private TextMeshProUGUI textComponent;
    private StandardMovement movementScript;
    private QuestHandler questScript;

    private int index;
    private bool inTrigger;
    private bool textOne = true;
    public bool textTwo;
    public bool textThree;

    private void Awake()
    {
        textComponent = GameObject.Find("TextBox").GetComponentInChildren<TextMeshProUGUI>();
        textBox = GameObject.Find("TextBox");

        movementScript = FindObjectOfType<StandardMovement>();
        questScript = FindObjectOfType<QuestHandler>();
    }

    private void Start()
    {
        textBox.SetActive(false);
        textComponent.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && inTrigger == true)
        {
            if (textOne == true)
            {
                if (textComponent.text == LinesOne[index])
                {
                    NextLine();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = LinesOne[index];
                }
            }

            else if (textTwo == true)
            {
                if (textComponent.text == LinesTwo[index])
                {
                    NextLine();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = LinesTwo[index];
                }
            }

            else if (textThree == true)
            {
                if (textComponent.text == LinesThree[index])
                {
                    NextLine();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = LinesThree[index];
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        movementScript.enabled = false;
        textBox.SetActive(true);
        inTrigger = true;
        StartDialogue();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textBox.SetActive(false);
        inTrigger = false;
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (textOne == true)
        {
            foreach (char c in LinesOne[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(TextSpeed);
            }
        }

        else if (textTwo == true)
        {
            foreach (char c in LinesTwo[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(TextSpeed);
            }
        }

        else if (textThree == true)
        {
            foreach (char c in LinesThree[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(TextSpeed);
            }
        }
    }

    void NextLine()
    {
        if (textOne == true)
        {
            if (index < LinesOne.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            
            else
            {
                textComponent.ClearMesh();
                textBox.SetActive(false);
                movementScript.enabled = true;
                textOne = false;
                textTwo = true;
                questScript.HasQuestStarted = true;
            }
        }

        else if (textTwo == true)
        {
            if (index < LinesTwo.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }

            else
            {
                textComponent.ClearMesh();
                textBox.SetActive(false);
                movementScript.enabled = true;
            }
        }

        else if (textThree == true)
        {
            if (index < LinesThree.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }

            else
            {
                textComponent.ClearMesh();
                textBox.SetActive(false);
                movementScript.enabled = true;
            }
        }
    }
}
