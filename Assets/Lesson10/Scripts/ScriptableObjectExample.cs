using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="CharacterInfo", menuName ="ScriptableObjects/CharacterInfo")]
public class ScriptableObjectExample : ScriptableObject {
    public int health;
    [Header("Characteristics")]
    public int agility;
    public int strength;
    public int intelligence;
    [Range(0f,1f)]
    public float luck;
}
