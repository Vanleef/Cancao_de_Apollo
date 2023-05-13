using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using NaughtyAttributes;

[Serializable]
public class Level
{
    public string sceneName = "Fase1";

    public bool hasTutorial = false;

    public string tutorialName = "Tutorial";

    public bool finalLevel = false;

    public string fullSong = "Final1";

    [Dropdown("Pontuação")]
    public int minScore = 0;
    private int[] Pontuação = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

    [Dropdown("Tentativas")]
    public int maxTry = 0;
    private int[] Tentativas = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };



}
