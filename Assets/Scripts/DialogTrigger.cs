using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DialogTrigger : MonoBehaviour
{

    public Dialog d;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().startD(d);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Ending");
    }

}
