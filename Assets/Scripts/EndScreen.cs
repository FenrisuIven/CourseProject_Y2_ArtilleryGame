using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] 
    public string playerName;
    public TMP_Text loserTxt;
    
    public GameObject playerControllers;
    
    
    private void Awake()
    {
        playerControllers.SetActive(false);
        loserTxt.text = $"{playerName} has lost.";
    }
}
