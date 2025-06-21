using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public string destination;
    public void Init(string destination)
    {
        this.destination = destination;
    }
}
