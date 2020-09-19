using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Icollectable 
{
    int ScoreValue { get; set; }
    void HideTheCollectable();
}
