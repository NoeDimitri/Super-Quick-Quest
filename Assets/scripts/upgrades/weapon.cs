using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : equipment
{

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#FF6347", out associatedColor);
    }

}
