using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Scriptable Objects/Levels")]

[Serializable]
public class Levels : ScriptableObject
{
    public int nbRings = 10;
    public GameObject startRing;
    public GameObject endRing;
    public List<GameObject> rings = new List<GameObject>();
    public float ringDistance = 5f;
    public Vector2 rangeRotation;
}
