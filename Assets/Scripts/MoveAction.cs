using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
    PlayerMovement player;
    public float ammount;

    private void Start()
    {
        player = PlayerManager.instance.player.GetComponent<PlayerMovement>();
    }
    
    public override void PerformAction()
    {
        StartCoroutine(ActionBehaviour());
    }

    IEnumerator ActionBehaviour()
    {
        running = true;
        player.Move(ammount);
        yield return new WaitUntil(() => !player.runningRoutine);
        running = false;
    }
}
