using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog : MonoBehaviour
{

    public ButtonEvent choice;
    public bool rightPath = false;
    public bool miniGame = false;

    [TextArea(3, 10)]
    public string[] sentences;

}
