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
    public void ReceiveLetter(Letter letter)
    {
        if (!HasLetter() && letter.destination == id)
        {
            ownerLetter = letter;
        }
        else
        {
            Debug.Log("Khong gui duoc thu");
        }
    }
}
