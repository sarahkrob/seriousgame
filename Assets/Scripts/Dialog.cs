using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog : MonoBehaviour
{

    public ButtonEvent choice;

    [TextArea(3, 10)]
    public string[] sentences;

}
