using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointClick : MonoBehaviour
{

    bool interactable; //can this object currently be clicked
    public UnityEvent OnClick = new UnityEvent();
    public Sprite swapSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        interactable = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (interactable && (StateManager.Instance.inDialogue == false)) 
        {
            //save current object we're interacting with
            StateManager.Instance.Object = gameObject;
            StateManager.Instance.inDialogue = true;
            interactable = false;
            OnClick.Invoke();
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
        StateManager.Instance.Object = null;
        StateManager.Instance.inDialogue = false;
        spriteRenderer.sprite = swapSprite;
    }

    public void dialogueIncorrect()
    {
        StateManager.Instance.Object = null;
        StateManager.Instance.inDialogue = false;
        interactable = true;
    }

}
