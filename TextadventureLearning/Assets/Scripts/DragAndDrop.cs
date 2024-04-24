using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Sprite seeds;
    
    private RectTransform rectTrans;
    private Image image;

    private QuestHandler questScript;

    public bool GoodSoul;
    public bool BadSoul;
    public bool Seed;
    public bool Water;

    public float timer = 0;
    private bool auraFinder;
    private GameObject collisionObject;


    public void OnBeginDrag(PointerEventData eventData)
    {
        //image.color = new Color32(255, 255, 255, 170);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //rectTrans.anchoredPosition += eventData.delta;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //image.color = new Color32(255, 255, 255, 255);
    }

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        questScript = FindObjectOfType<QuestHandler>();
    }

    private void Update()
    {
        if (auraFinder == true)
        {
            timer += 1 * Time.deltaTime;

            if (timer >= 5)
            {
                auraFinder = false;
                timer = 0;
                questScript.TanimQuestCount++;
                collisionObject.GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag))
        {
            Destroy(gameObject);
            questScript.PanulaanQuestCount++;
        }

        if (GoodSoul == true)
        {
            questScript.PagsuyoQuestCount++;
            Destroy(gameObject);
        }

        if (BadSoul == true)
        {
            questScript.PagsuyoQuestCount--;
        }

        if (Seed == true && collision.gameObject.tag == "Water")
        {
            gameObject.tag = "QuestObject";
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<DragAndDrop>().enabled = false;
        }

        if (Water == true && collision.gameObject.tag == "QuestObject")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Image>().sprite = seeds;
            questScript.LupaQuestCount++;
        }

        if (collision.gameObject.tag == "Tree")
        {
            auraFinder = true;
            collisionObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (BadSoul == true)
        {
            questScript.PagsuyoQuestCount++;
        }

        if (Seed == true && collision.gameObject.tag == "QuestObject")
        {
            gameObject.GetComponent<DragAndDrop>().enabled = false;
        }

        if (collision.gameObject.tag == "Tree")
        {
            auraFinder = false;
        }
    }
}
