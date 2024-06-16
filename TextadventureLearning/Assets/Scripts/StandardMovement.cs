using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D playerCollider;
    public Animator PlayerAnimator;
    private float vertical;
    private float horizontal;

    [SerializeField] private int movementSpeed = 5;
    [SerializeField] private GameObject uiObject;

    private QuestHandler questScript;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        PlayerAnimator = GetComponentInChildren<Animator>();

        questScript = FindObjectOfType<QuestHandler>();
        
        uiObject.SetActive(false);
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Horizontal");
        horizontal = Input.GetAxisRaw("Vertical");

        rigidBody.velocity = new Vector2(vertical * movementSpeed, horizontal * movementSpeed);

        SetAnimations(rigidBody.velocity);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (questScript.HasQuestStarted == true && questScript.LevelTwo == false)
    //    {
    //        uiObject.SetActive(true);
    //    }

    //    if (collision.gameObject.tag == "Houses")
    //    {
    //        uiObject.SetActive(true);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    uiObject.SetActive(false);
    //}

    private void SetAnimations(Vector2 velocity)
    {
        if (velocity.magnitude > 1)
        {
            PlayerAnimator.SetBool("IsMoving", true);

            if (vertical <= -0.9f)
            {
                PlayerAnimator.SetBool("Front", false);
                PlayerAnimator.SetBool("Back", false);
                PlayerAnimator.SetBool("Left", false);
                PlayerAnimator.SetBool("Right", true);

                gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }

            else if (vertical >= 0.9f)
            {
                PlayerAnimator.SetBool("Front", false);
                PlayerAnimator.SetBool("Back", false);
                PlayerAnimator.SetBool("Left", true);
                PlayerAnimator.SetBool("Right", false);

                gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }

            else if (horizontal >= 0.9f)
            {
                PlayerAnimator.SetBool("Front", true);
                PlayerAnimator.SetBool("Back", false);
                PlayerAnimator.SetBool("Left", false);
                PlayerAnimator.SetBool("Right", false);

                gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }

            else if (horizontal <= -0.9f)
            {
                PlayerAnimator.SetBool("Front", false);
                PlayerAnimator.SetBool("Back", true);
                PlayerAnimator.SetBool("Left", false);
                PlayerAnimator.SetBool("Right", false);

                gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }

        else
        {
            PlayerAnimator.SetBool("IsMoving", false);
        }
    }
}
