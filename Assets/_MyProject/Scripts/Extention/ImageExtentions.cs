using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ColorExtension
/// </summary>
public static class ImageExtentions 
{
    // Set
    public static void SetColor(this Image src, Color col)
    {
        src.color = new Color(col.r,col.g,col.b,col.a);
    }
}
