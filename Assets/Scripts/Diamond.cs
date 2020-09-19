using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour, Icollectable
{
    public int ScoreValue { get; set; }

    private void Start()
    {
        ScoreValue = 10;
    }

    public void HideTheCollectable()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(HidingIenum());

    }

    IEnumerator HidingIenum()
    {
        float begginningTime = Time.time;
        while (Time.time- begginningTime < 1)
        {
            yield return null;
            transform.Rotate(Vector3.up);
        }
        GetComponent<ObjectGenerator>().SetObjet();
    }

}
