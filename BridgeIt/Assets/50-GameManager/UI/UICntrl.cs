using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICntrl : MonoBehaviour
{
    public static event Action OnPlay = delegate {};

    public static event Action OnNewMaze = delegate {};

    public static event Action<int> OnScoreUpdate = delegate {};

    [SerializeField] private TMP_Text scoreTxt;

    private int score = 0;
    
    private void Start() 
    {
        AddToScore(0);  
    }

    public void AddToScore(int delta) 
    {
        score += delta;
        scoreTxt.text = score.ToString();

        OnScoreUpdate?.Invoke(score);
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
