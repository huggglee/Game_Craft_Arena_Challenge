using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterReceiver : MonoBehaviour
{
    public string id;
    public Letter ownerLetter;

    public bool HasLetter()
    {
        return ownerLetter != null;
    }
}
