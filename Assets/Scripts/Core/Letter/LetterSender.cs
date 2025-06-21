using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LetterSender : Singleton<LetterSender>
{
    public Letter letters;
    public LetterReceiver[] letterReceiver;
    public Transform letterRevCon;
    public List<Transform> spawnPosSer;
    [SerializeField] List<Letter> letterList = new();
    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int i = 0;
        List<Transform> spawnPos = new();
        for (int j = 0; j < spawnPosSer.Count; j++)
        {
            spawnPos.Add(spawnPosSer[j]);
        }
        Debug.Log(spawnPos.Count);
        while (spawnPos.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnPos.Count);
            Transform spawnPoint = spawnPos[randomIndex];
            spawnPos.Remove(spawnPoint);

            LetterReceiver letterRevPrefabs = letterReceiver[i];
            if(letterRevPrefabs != null)
            {
                Instantiate(letterRevPrefabs, spawnPoint.position, Quaternion.identity, letterRevCon);
                Letter newLetter = Instantiate(letters);
                newLetter.Init(letterRevPrefabs.id); 
                letterList.Add(newLetter);
            }
            i++;
        }
    }
    public List<Letter> GetLetters()
    {

        List<Letter> tempList = new();
        for (int j = 0; j < letterList.Count; j++)
        {
            tempList.Add(letterList[j]);
        }
        letterList.Clear();
        return tempList;
    }
    public int GetLetterCount()
    {
        return letterList.Count;
    }


}
