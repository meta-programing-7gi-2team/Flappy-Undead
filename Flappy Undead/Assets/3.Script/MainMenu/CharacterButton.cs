using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    public GameObject Character;

    public void Character_Open()
    {
        Character.SetActive(true);
    }

    public void Character_Exit()
    {
        Character.SetActive(false);
    }
}
