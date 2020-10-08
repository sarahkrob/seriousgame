using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ButtonEvent : MonoBehaviour
{

    [TextArea(3, 10)]
    public string choice1;
    public Dialog response1;
    [TextArea(3, 10)]
    public string choice2;
    public Dialog response2;
    [TextArea(3, 10)]
    public string choice3;
    public Dialog response3;
}
