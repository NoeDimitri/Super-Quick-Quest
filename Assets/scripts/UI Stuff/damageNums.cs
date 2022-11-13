using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageNums : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.75f);
        transform.localPosition += new Vector3(0.25f + Random.Range(0f,0.3f), 0.5f + Random.Range(0f, 0.1f), -2.0f);
    }


}
