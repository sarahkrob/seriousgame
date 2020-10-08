using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialog;
    public Canvas canvas;
    private Queue<string> sentences;
    private bool eventPresent;
    private Dialog currentDialog;
    private GameObject dialogBox;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    // Start is called before the first frame update
    void Start()
    {
        eventPresent = false;
        sentences = new Queue<string>();
        canvas.enabled = false;
        StateManager.Instance.inDialogue = false;
        dialogBox = GameObject.Find("Dialog Box");


    }

    public void startD(Dialog d)
    {
        currentDialog = d;
        if(d.choice)
        {
            eventPresent = true;
            button1.GetComponentInChildren<Text>().text = d.choice.choice1;
            button2.GetComponentInChildren<Text>().text = d.choice.choice2;
            button3.GetComponentInChildren<Text>().text = d.choice.choice3;
        }
        else
        {
            eventPresent = false;
        }
        if (canvas.enabled == false)
        {
            canvas.enabled = true;
        }
        if (!dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(true);
        }
        if (button1.activeInHierarchy || button2.activeInHierarchy || button3.activeInHierarchy)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
        }
        sentences.Clear();
        foreach(string sent in d.sentences)
        {
            sentences.Enqueue(sent);
        }
        DisplayNextSent();
    }

    public void DisplayNextSent()
    {
        if (sentences.Count == 0 && eventPresent) 
        {
            dialogBox.SetActive(false);
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            button1.GetComponent<Button>().onClick.AddListener(delegate { startD(currentDialog.choice.response1); });
            button2.GetComponent<Button>().onClick.AddListener(delegate { startD(currentDialog.choice.response2); });
            button3.GetComponent<Button>().onClick.AddListener(delegate { startD(currentDialog.choice.response3); });
        }
        else if (sentences.Count == 0 )
        {
            EndDialog();
            return;
        }
        else
        {
            string returnSentence = sentences.Dequeue();
            dialog.text = returnSentence;
        }
        
    }

    void EndDialog()
    {
        UnityEngine.Debug.Log(StateManager.Instance.Object.name);
        StateManager.Instance.Object.GetComponent<PointClick>().dialogueComplete();
        canvas.enabled = false;
    }
}
