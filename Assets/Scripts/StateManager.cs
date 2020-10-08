﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance { get; private set; }
    public GameObject Object;
    public bool inDialogue; //detects if player is currently in dialogue

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}