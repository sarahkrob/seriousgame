using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointClick : MonoBehaviour
{

    bool interactable; //can this object currently be clicked
    bool complete;
    public UnityEvent OnClick = new UnityEvent();
    public Sprite swapSprite;
    public Sprite newPlayerSprite;
    private SpriteRenderer spriteRenderer;
    private GameObject player;
    

    void Start()
    {
        interactable = true;
        complete = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!complete && !StateManager.Instance.inMinigame)
            interactable = true;
        else if (complete || StateManager.Instance.inMinigame)
            interactable = false;
    }

    void OnMouseDown()
    {
        if (interactable && (StateManager.Instance.inDialogue == false)) 
        {
            if(StateManager.Instance.finishedObjects!=0||CompareTag("Bed"))
            {
                if(CompareTag("Clock"))
                {
                    player.GetComponentsInChildren<SpriteRenderer>()[1].sprite = newPlayerSprite;
                }
                if(CompareTag("Shelf"))
                {
                    player.GetComponentsInChildren<SpriteRenderer>()[1].sprite = newPlayerSprite;
                }
                //save current object we're interacting with
                StateManager.Instance.Object = gameObject;
                StateManager.Instance.inDialogue = true;
                interactable = false;
                OnClick.Invoke();
            }
            
        }
    }

    void OnMouseEnter()
    {
        if (interactable && (StateManager.Instance.inDialogue == false) && (gameObject.tag != "Background"))
            transform.localScale += new Vector3(0.25f, 0.25f, 0);
    }

    void OnMouseExit()
    {
        if (interactable && (StateManager.Instance.inDialogue == false) && (gameObject.tag != "Background"))
            transform.localScale -= new Vector3(0.25f, 0.25f, 0);
    }

    public void dialogueCorrect()
    {
        complete = true;
        StateManager.Instance.Object = null;
        StateManager.Instance.inDialogue = false;
        spriteRenderer.sprite = swapSprite;
        player.GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;

        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>() )
        {
            if ((!sr.gameObject.CompareTag("Main Object")) && (!sr.gameObject.CompareTag("Bed")) && (!sr.gameObject.CompareTag("Shelf")) && (!sr.gameObject.CompareTag("Clock")))
            {
                sr.gameObject.SetActive(false);
            }
        }
        if(StateManager.Instance.finishedObjects == 0)
        {

            player.GetComponent<SpriteRenderer>().sprite = newPlayerSprite;
            player.transform.position = new Vector3(4,-5.5f,0);
        }

    }

    public void dialogueIncorrect()
    {
        StateManager.Instance.Object = null;
        StateManager.Instance.inDialogue = false;
        interactable = true;
    }

}
