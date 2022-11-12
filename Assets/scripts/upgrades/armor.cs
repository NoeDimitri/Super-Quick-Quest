using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armor : equipment
{
    public int def;
    private void Start()
    {

        ColorUtility.TryParseHtmlString("#1E90FF", out associatedColor);
    }

}
