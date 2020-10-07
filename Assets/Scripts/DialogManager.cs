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

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        canvas.enabled = false;
        StateManager.Instance.inDialogue = false;
    }

    public void startD(Dialog d)
    {
        if (canvas.enabled == false)
        {
            canvas.enabled = true;
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
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string returnSentence = sentences.Dequeue();
        dialog.text = returnSentence;
    }

    void EndDialog()
    {
        UnityEngine.Debug.Log(StateManager.Instance.Object.name);
        StateManager.Instance.Object.GetComponent<PointClick>().dialogueComplete();
        canvas.enabled = false;
    }
}
