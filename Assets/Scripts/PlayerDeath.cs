using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] GameEvent onPlayerDeath;
    [SerializeField] BoolValue gameRunning;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
                Crash();
    }

    void Crash()
    {
        GetComponent<Animator>().SetTrigger("Death");
        gameRunning.Value = false;
        StartCoroutine(RaiseOnPlayerDeath());
    }

    IEnumerator RaiseOnPlayerDeath()
    {
        yield return new WaitForSeconds(3);
        onPlayerDeath.Raise();
        GetComponent<Animator>().enabled = false;
    }


}
