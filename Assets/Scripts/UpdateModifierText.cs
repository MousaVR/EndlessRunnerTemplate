using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateModifierText : MonoBehaviour
{
    [SerializeField] FloatVariable modifierAmount;
    float modifier;
    public void OnUpdateModifierTextListener()
    {
        modifier = 1.0f + modifierAmount.Value;
        GetComponent<Text>().text = "x" + modifier.ToString("0.0");
    }

}
