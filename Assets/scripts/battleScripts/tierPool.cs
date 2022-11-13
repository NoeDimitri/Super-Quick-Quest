using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tierPool : MonoBehaviour
{
    public encounter[] encounterPool;

    public int getLength()
    {
        return encounterPool.Length;
    }

    public encounter getEncounter(int i)
    {
        return encounterPool[i];
    }
    
}
