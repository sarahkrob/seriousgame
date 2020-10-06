using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogTrigger : MonoBehaviour
{

    public Dialog d;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().startD(d);
    }

}
