using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class DialogueManagement : MonoBehaviour
{
    [SerializeField] private string[] linesOne;
    [SerializeField] private string[] linesTwo;
    [SerializeField] private string[] linesThree;
    [SerializeField] private string[] linesFour;
    [SerializeField] private string[] linesFive;
    [SerializeField] private string[] linesSix;
    [SerializeField] private float textSpeed;
    [SerializeField] private bool isKagiliran;
    [SerializeField] private bool isIntro;
    [SerializeField] private bool isKatalusan;
    [SerializeField] private bool isDream;
    [SerializeField] private bool isLvl2;
    [SerializeField] private bool isPaglikha;

    public GameObject CharacterArt;
    public GameObject TextBox;
    private TextMeshProUGUI textComponent;
    private StandardMovement movementScript;
    private QuestHandler questScript;
    private TaskManager taskScript;
    private TriggerUI triggerScript;

    private int index;
    private bool inTrigger;
    public bool TextOne = true;
    public bool TextTwo;
    public bool TextThree;
    private bool textFour;
    private bool textFive;
    private bool textSix;

    private void Awake()
    {
        textComponent = GameObject.Find("TextBox").GetComponentInChildren<TextMeshProUGUI>();
        TextBox = GameObject.Find("TextBox");

        movementScript = FindObjectOfType<StandardMovement>();
        questScript = FindObjectOfType<QuestHandler>();
        taskScript = FindObjectOfType<TaskManager>();
        triggerScript = FindObjectOfType<TriggerUI>();
    }

    private void Start()
    {
        TextBox.SetActive(false);
        textComponent.text = string.Empty;
    }

    private void Update()
    {
        if (questScript.HayopQuestCount >= 7 && isDream == true)
        {
            TextOne = false;
            TextTwo = true;
        }

        if (Input.GetMouseButtonDown(0) && inTrigger == true)
        {
            if (TextOne == true)
            {
                if (textComponent.text == linesOne[index])
                {
                    NextLine();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = linesOne[index];
                }
            }

            else if (TextTwo == true && isLvl2 == false)
            {
                if (textComponent.text == linesTwo[index])
                {
                    NextLine();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = linesTwo[index];
                }
            }

            else if (TextThree == true)
            {
                if (textComponent.text == linesThree[index])
                {
                    NextLine();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = linesThree[index];
                }
            }

            else if (textFour == true)
            {
                if (textComponent.text == linesFour[index])
                {
                    NextLine();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = linesFour[index];
                }
            }

            else if (textFive == true)
            {
                if (textComponent.text == linesFive[index])
                {
                    NextLine();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = linesFive[index];
                }
            }

            else if (textSix == true)
            {
                if (textComponent.text == linesSix[index])
                {
                    NextLine();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = linesSix[index];
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        movementScript.PlayerAnimator.SetBool("IsMoving", false);
        movementScript.enabled = false;
        movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        if (isLvl2 == false)
        {
            TextBox.SetActive(true);
            CharacterArt.SetActive(true);
            inTrigger = true;
            StartDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TextBox.SetActive(false);
        CharacterArt.SetActive(false);
        inTrigger = false;
    }

    public void StartDialogue()
    {
        index = 0;
        CharacterArt.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (TextOne == true)
        {
            foreach (char c in linesOne[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        else if (TextTwo == true)
        {
            foreach (char c in linesTwo[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        else if (TextThree == true)
        {
            foreach (char c in linesThree[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        else if (textFour == true)
        {
            foreach (char c in linesFour[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        else if (textFive == true)
        {
            foreach (char c in linesFive[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        else if (textSix == true)
        {
            foreach (char c in linesSix[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    void NextLine()
    {
        if (TextOne == true)
        {
            if (index < linesOne.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            
            else
            {
                textComponent.ClearMesh();
                TextBox.SetActive(false);
                CharacterArt.SetActive(false);
                movementScript.enabled = true;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                if (isKagiliran == false)
                {
                    TextOne = false;
                    TextTwo = true;
                    questScript.HasQuestStarted = true;

                    if (questScript.LevelTwo == true && isPaglikha == false)
                    {
                        TextOne = true;
                        TextTwo = false;
                    }
                }

                if (isIntro == true)
                {
                    TextTwo = false;
                    gameObject.transform.parent.gameObject.SetActive(false);
                    questScript.HasQuestStarted = false;
                }

                if (isKatalusan == true)
                {
                    questScript.HasQuestStarted = false;
                }

                if (isDream == true)
                {
                    GetComponent<SpriteRenderer>().sprite = CharacterArt.GetComponent<Image>().sprite;
                    GetComponent<StartQuestHayop>().PetGettable = true;
                    Destroy(GetComponent<DialogueManagement>());
                }
            }
        }

        else if (TextTwo == true)
        {
            if (index < linesTwo.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }

            else
            {
                textComponent.ClearMesh();
                TextBox.SetActive(false);
                CharacterArt.SetActive(false);
                movementScript.enabled = true;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                if (isKatalusan == true)
                {
                    TextTwo = false;
                    TextThree = true;
                }

                if (isDream == true)
                {
                    GetComponent<SpriteRenderer>().sprite = CharacterArt.GetComponent<Image>().sprite;
                    GetComponent<StartQuestHayop>().PetGettable = true;
                    triggerScript.IsSpacable = true;
                    Destroy(GetComponent<DialogueManagement>());
                }
            }
        }

        else if (TextThree == true)
        {
            if (index < linesThree.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }

            else
            {
                textComponent.ClearMesh();
                TextBox.SetActive(false);
                CharacterArt.SetActive(false);
                movementScript.enabled = true;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                if (isKatalusan == true)
                {
                    TextThree = false;
                    textFour = true;
                }
            }
        }

        else if (textFour == true)
        {
            if (index < linesFour.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }

            else
            {
                textComponent.ClearMesh();
                TextBox.SetActive(false);
                CharacterArt.SetActive(false);
                movementScript.enabled = true;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                if (isKatalusan == true)
                {
                    textFour = false;
                    textFive = true;
                }
            }
        }

        else if (textFive == true)
        {
            if (index < linesFive.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }

            else
            {
                textComponent.ClearMesh();
                TextBox.SetActive(false);
                CharacterArt.SetActive(false);
                movementScript.enabled = true;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                if (isKatalusan == true)
                {
                    textFive = false;
                    textSix = true;
                }
            }
        }

        else if (textSix == true)
        {
            if (index < linesSix.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }

            else
            {
                textComponent.ClearMesh();
                TextBox.SetActive(false);
                CharacterArt.SetActive(false);
                movementScript.enabled = true;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                movementScript.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                if (isKatalusan == true)
                {
                    textSix = false;
                    TextOne = true;
                }
            }
        }
    }
}
