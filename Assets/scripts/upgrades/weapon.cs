using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : equipment
{
    public float damageMultiplier;
    public float atkSpeedMultiplier;
    private void Start()
    {
        ColorUtility.TryParseHtmlString("#FF6347", out associatedColor);
    }

}
