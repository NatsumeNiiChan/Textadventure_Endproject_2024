using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Sprite seeds;
    [SerializeField] private GameObject rope;
    
    private RectTransform rectTrans;
    private Image image;

    private QuestHandler questScript;

    public bool GoodSoul;
    public bool BadSoul;
    public bool Seed;
    public bool Water;
    public bool IsRope;
    public bool Ring;
    private bool inBook;

    public float timer = 0;
    private bool auraFinder;
    private bool drumFinder;
    private GameObject collisionObject;
    private bool inTrigger;

    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioClip loopClip;
    private AudioSource sound;

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

        if (inTrigger == true && Ring == true)
        {
            rope.GetComponent<DragAndDrop>().IsRope = true;
            gameObject.GetComponent<DragAndDrop>().enabled = false;
            sound.clip = clip;
            sound.Play();
        }

        if (inTrigger == true && inBook == true)
        {
            questScript.PanulaanQuestCount++;
            sound.clip = clip;
            sound.Play();
            gameObject.GetComponent<DragAndDrop>().enabled = false;
        }
    }

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        questScript = FindObjectOfType<QuestHandler>();
        sound = GameObject.Find("SoundHandler").GetComponent<AudioSource>();
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
                sound.clip = clip;
                sound.Play();
                collisionObject.GetComponent<PolygonCollider2D>().enabled = false;
                collisionObject.GetComponent<Image>().enabled = true;
            }
        }

        if (drumFinder == true)
        {
            timer += 1 * Time.deltaTime;

            if (timer >= 1)
            {
                drumFinder = false;
                timer = 0;
                questScript.YariQuestCount++;
                sound.clip = clip;
                sound.Play();

                if (collisionObject.tag != "Laguz")
                {
                    collisionObject.GetComponent<Image>().color = new Color32(100, 70, 30, 255);
                }

                collisionObject.GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;

        if (collision.gameObject.CompareTag(gameObject.tag))
        {
            inBook = true;
        }

        if (GoodSoul == true)
        {
            questScript.PagsuyoQuestCount++;
            sound.clip = clip;
            sound.Play();
            Destroy(gameObject);
        }

        if (BadSoul == true)
        {
            questScript.PagsuyoQuestCount--;
            sound.clip = clip;
            sound.Play();
        }

        if (Seed == true && collision.gameObject.tag == "Water")
        {
            gameObject.tag = "QuestObject";
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<DragAndDrop>().enabled = false;
            sound.clip = clip;
            sound.Play();
        }

        if (Water == true && collision.gameObject.tag == "QuestObject")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Image>().sprite = seeds;
            questScript.LupaQuestCount++;
            sound.clip = clip;
            sound.Play();
        }

        if (collision.gameObject.tag == "Tree")
        {
            auraFinder = true;
            sound.clip = loopClip;
            sound.loop = true;
            sound.Play();
            collisionObject = collision.gameObject;
        }

        if (IsRope == true)
        {
            drumFinder = true;
            sound.clip = loopClip;
            sound.loop = true;
            sound.Play();
            collisionObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;

        if (collision.gameObject.CompareTag(gameObject.tag))
        {
            inBook = false;
        }

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
            sound.clip = loopClip;
            sound.loop = false;
            sound.Stop();
        }

        if (IsRope == true)
        {
            drumFinder = false;
            sound.clip = loopClip;
            sound.loop = false;
            sound.Stop();
            collisionObject = collision.gameObject;
        }
    }
}
