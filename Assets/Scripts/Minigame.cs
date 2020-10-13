using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{

    public Text seeText;
    public Text touchText;
    public Text hearText;
    public Text smellText;
    public Text tasteText;
    public GameObject masterNode;
    public GameObject Interactables;
    public GameObject winScreen;
    private Color32 finishedColor;

    // Start is called before the first frame update
    void Start()
    {
        MinigameManager.Instance.currentRound = "See";
        MinigameManager.Instance.roundCounter = 0;
        finishedColor = new Color32(185, 172, 172, 255);
    }

    // Update is called once per frame
    void Update()
    {
        switch(MinigameManager.Instance.currentRound)
        {
            case "See":
                if (MinigameManager.Instance.roundCounter == 5)
                {
                    seeText.color = finishedColor;
                    MinigameManager.Instance.currentRound = "Touch";
                    MinigameManager.Instance.roundCounter = 0;
                }
                break;
            case "Touch":
                if (MinigameManager.Instance.roundCounter == 4)
                {
                    touchText.color = finishedColor;
                    MinigameManager.Instance.currentRound = "Hear";
                    MinigameManager.Instance.roundCounter = 0;
                }
                break;
            case "Hear":
                if (MinigameManager.Instance.roundCounter == 3)
                {
                    hearText.color = finishedColor;
                    MinigameManager.Instance.currentRound = "Smell";
                    MinigameManager.Instance.roundCounter = 0;
                }
                break;
            case "Smell":
                if (MinigameManager.Instance.roundCounter == 2)
                {
                    smellText.color = finishedColor;
                    MinigameManager.Instance.currentRound = "Taste";
                    MinigameManager.Instance.roundCounter = 0;
                }
                break;
            case "Taste":
                if (MinigameManager.Instance.roundCounter == 1)
                {
                    tasteText.color = finishedColor;
                    winScreen.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    public void DeactivateScene()
    {
        StateManager.Instance.inMinigame = false;
        StateManager.Instance.Interactables.SetActive(true);
        masterNode.SetActive(false);
    }
}
