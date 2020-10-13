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
    private bool button1enabled;
    public GameObject button2;
    private bool button2enabled;
    public GameObject button3;
    private bool button3enabled;
    public GameObject Minigame;
    public GameObject Interactables;
    public GameObject endingObjects;

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
        UnityEngine.Debug.Log(eventPresent);
        if (d.choice!=null)
        {
            eventPresent = true;
            if (d.choice.choice1 != "")
            {
                button1.GetComponentInChildren<Text>().text = d.choice.choice1;
                button1enabled = true;
                button1.GetComponent<Button>().onClick.RemoveAllListeners();
            }
            else
                button1enabled = false;
            if (d.choice.choice2 != "")
            {
                button2.GetComponentInChildren<Text>().text = d.choice.choice2;
                button2enabled = true;
                button2.GetComponent<Button>().onClick.RemoveAllListeners();
            }
            else
                button2enabled = false;
            if (d.choice.choice3 != "")
            {
                button3.GetComponentInChildren<Text>().text = d.choice.choice3;
                button3enabled = true;
                button3.GetComponent<Button>().onClick.RemoveAllListeners();
            }
            else
                button3enabled = false;
        }
        else
        {
            eventPresent = false;
            button1enabled = false;
            button2enabled = false;
            button3enabled = false;
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
        currentDialog = d;
        sentences.Clear();
        foreach(string sent in d.sentences)
        {
            sentences.Enqueue(sent);
        }
        DisplayNextSent();
    }

    public void DisplayNextSent()
    {
        UnityEngine.Debug.Log(eventPresent);

        if (sentences.Count == 0 && eventPresent) 
        {
            dialogBox.SetActive(false);
            if (button1enabled)
            {
                button1.SetActive(true);
                button1.GetComponent<Button>().onClick.AddListener(delegate { startD(currentDialog.choice.response1); });
            }
            if (button2enabled)
            {
                button2.SetActive(true);
                button2.GetComponent<Button>().onClick.AddListener(delegate { startD(currentDialog.choice.response2); });
            }
            if (button3enabled)
            {
                button3.SetActive(true);
                button3.GetComponent<Button>().onClick.AddListener(delegate { startD(currentDialog.choice.response3); });
            }  
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
        if (currentDialog.rightPath)
        {
            StateManager.Instance.Object.GetComponent<PointClick>().dialogueCorrect();
            StateManager.Instance.finishedObjects += 1;
            if (StateManager.Instance.finishedObjects == 4)
            {
                endingObjects.SetActive(true);
            }
        }
        else
        {
            if(currentDialog.miniGame)
            {
                Instantiate(Minigame);
                StateManager.Instance.inMinigame = true;
                StateManager.Instance.Object.GetComponent<PointClick>().dialogueIncorrect();
                Interactables.SetActive(false);
            }
            else
                StateManager.Instance.Object.GetComponent<PointClick>().dialogueIncorrect();
        }
        canvas.enabled = false;
    }
}
