using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    public void Init(string text)
    {
        tmp.text = text;
    }
}
