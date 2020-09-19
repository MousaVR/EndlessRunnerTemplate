using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// for speed increasing and modifier
/// </summary>
public class SpeedController : MonoBehaviour
{
    [SerializeField] FloatVariable speed;
    [SerializeField] FloatVariable modifierSpeed;
    [SerializeField] GameEvent OnUpdateModifierText;
    [SerializeField] BoolValue gameRunning;
    float originalSpeed = 5f;
    float speedIncreaseLastTick = 0;
    float speedIcreaseTime = 3f;
    float speedIncreaseAmount = .1f;
    
    void Start()
    {
        speed.Value= originalSpeed;
        modifierSpeed.Value =0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameRunning.Value) return;
        if (Time.time - speedIncreaseLastTick > speedIcreaseTime)
        {
            speedIncreaseLastTick = Time.time;
            speed.Value += speedIncreaseAmount;
            modifierSpeed.Value=(speed.Value - originalSpeed)*.1f;
            OnUpdateModifierText.Raise();
        }
    }
}
