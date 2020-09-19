using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsController : MonoBehaviour
{
    [SerializeField] IntVariable coins;
    [SerializeField] IntVariable score;
    [SerializeField] FloatVariable speedModifier;
    [SerializeField] GameEvent onHitCollectable;
    [SerializeField] GameEvent onUpdateScoreText;
    [SerializeField] BoolValue gameRunning;
    
    float tempScore;

    private void Start()
    {
        score.Value = coins.Value = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Icollectable collectable = other.gameObject.GetComponent<Icollectable>();
            coins.Value+=collectable.ScoreValue;
            collectable.HideTheCollectable();
            onHitCollectable.Raise();
        }
    }

    private void Update()
    {
        if (gameRunning.Value)
        {
            tempScore += Time.deltaTime * speedModifier.Value*10;
            //for optimizing when to updte score text
            if (score.Value != (int)tempScore)
            {
                score.Value = (int)tempScore;
                onUpdateScoreText.Raise();
            }
        }
    }
}
