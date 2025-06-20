using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LetterSender : Singleton<LetterSender>
{
    public Letter letters;
    public LetterReceiver[] letterReceiver;
    public Transform letterRevCon;
    public List<Transform> spawnPos;
    private List<Letter> letterList = new();
    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int i = 0;
        while(spawnPos.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnPos.Count);
            Transform spawnPoint = spawnPos[randomIndex];
            spawnPos.Remove(spawnPoint);

            LetterReceiver letterPrefabs = letterReceiver[i];
            if(letterPrefabs != null)
            {
                Instantiate(letterPrefabs, spawnPoint.position, Quaternion.identity, letterRevCon);
                Letter newLetter = Instantiate(letters);
                letterList.Add(newLetter);
            }
            i++;
        }
    }

}
