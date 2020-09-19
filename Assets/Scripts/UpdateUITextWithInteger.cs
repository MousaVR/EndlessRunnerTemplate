using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUITextWithInteger : MonoBehaviour
{
    [SerializeField]IntVariable theUpdatedValue;

    private void OnEnable()
    {
        UpdateUITextWithIntegerListener();
    }

    public void UpdateUITextWithIntegerListener()
    {
        GetComponent<Text>().text = theUpdatedValue.Value.ToString();
    }
}
