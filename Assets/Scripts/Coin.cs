using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, Icollectable
{

    public int ScoreValue { get; set; }

    private void Start()
    {
        ScoreValue = 5;
    }

    public void HideTheCollectable()
    {
        GetComponent<ObjectGenerator>().SetObjet();

    }

}
