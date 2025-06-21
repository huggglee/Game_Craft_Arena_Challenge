using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LetterContainerUI : MonoBehaviour
{
    public LetterUI letterPrefabs;
    Dictionary<string, LetterUI> letterDic = new();

    private void Start()
    {
        Observer.Instance.Register(EventId.OnUpdateLetter, LetterContainer_OnUpdateLetter);
    }
    void LetterContainer_OnUpdateLetter(object obj)
    {
        var data = obj as Tuple<Letter, int>;
        Letter letter = data.Item1;
        int signal = data.Item2;
        if(signal == 1)
        {
            LetterUI letterUI = Instantiate(letterPrefabs, transform);
            letterUI.Init(letter.destination);
            letterDic.Add(letter.destination,letterUI);
        }
        else if(signal == -1)
        {
            LetterUI letterUI = letterDic[letter.destination];
            letterDic.Remove(letter.destination);
            Destroy(letterUI.gameObject);
        }
    }

    private void OnDestroy()
    {
        Observer.Instance.Unregister(EventId.OnUpdateLetter, LetterContainer_OnUpdateLetter);
    }
}

