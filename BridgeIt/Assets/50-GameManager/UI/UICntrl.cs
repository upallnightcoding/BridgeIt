using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICntrl : MonoBehaviour
{
    public static event Action OnPlay = delegate {};

    public static event Action OnNewMaze = delegate {};

    [SerializeField] private TMP_Text scoreTxt;

    private int score;
    
    private void Start() 
    {
        SetScore(0);  
    }

    public void SetScore(int score) 
    {
        this.score = score;
        scoreTxt.text = score.ToString();
    }

    public void PlayGame()
    {
        OnPlay?.Invoke();
    }

    public void NewMaze()
    {
        OnNewMaze?.Invoke();
    }

}
