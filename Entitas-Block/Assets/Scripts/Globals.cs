﻿using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.UI;

[Game, Unique, CreateAssetMenu]
public class Globals : ScriptableObject
{
    public GameObject blockPrefab;
    public GameObject triangleBlockPrefab;
    public GameObject ballPrefab;
    public GameObject boundaryPrefab;
    public GameObject pointerPrefab;
    public GameObject bombPrefab;
    public GameObject laserPrefab;
    public GameObject linePrefab;
    public GameObject winScreenPrefab;
    public GameObject loseScreenPrefab;
}
