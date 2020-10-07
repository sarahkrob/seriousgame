using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointClick : MonoBehaviour
{

    bool interactable; //can this object currently be clicked
    public UnityEvent OnClick = new UnityEvent();

    void Start()
    {
        interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (interactable)
        {
            OnClick.Invoke();
        }
    }

    void OnMouseEnter()
    {
        Debug.Log("HOVER");
        transform.localScale += new Vector3(0.25f, 0.25f, 0);
    }

    void OnMouseExit()
    {
        transform.localScale -= new Vector3(0.25f, 0.25f, 0);
    }
}
