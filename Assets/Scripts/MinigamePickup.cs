using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamePickup : MonoBehaviour
{
    public GameObject circle;
    public GameObject x;
    private GameObject marker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }

    void OnMouseExit()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0);
    }

    void OnMouseDown()
    {
        if (gameObject.tag.Contains(MinigameManager.Instance.currentRound))
        {
            marker = Instantiate(circle, transform.position, transform.rotation);
        }
        else
        {
            marker = Instantiate(x, transform.position, transform.rotation);
        }
    }

    void OnMouseUp()
    {
        if (gameObject.tag.Contains(MinigameManager.Instance.currentRound))
        {
            MinigameManager.Instance.roundCounter += 1;
            Destroy(marker);
            Destroy(gameObject);
        }
        else
        {
            Destroy(marker, 2);
        }
    }
}
