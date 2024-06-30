using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CharType
{
    Normal,
    Witch,
    Axe,
    Horn
}

[CreateAssetMenu]
public class Player_Data : ScriptableObject
{
    public CharType Type;
    public int Health;
    public float Speed;
    public float CoolTime;
}
