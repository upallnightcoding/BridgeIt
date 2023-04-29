using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICntrl : MonoBehaviour
{
    public static event Action OnPlay = delegate {};

    public static event Action OnNewMaze = delegate {};

    public void PlayGame()
    {
        OnPlay?.Invoke();
    }

    public void NewMaze()
    {
        OnNewMaze?.Invoke();
    }
}
