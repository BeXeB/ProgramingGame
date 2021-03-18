using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatAction : Action
{
    [SerializeField] int times;
    [SerializeField] List<Action> actionsToRepeat;
    PlayerMovement player;

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
        for (int i = 0; i < times; i++)
        {
            foreach (Action action in actionsToRepeat)
            {
                yield return new WaitUntil(() => !player.runningRoutine);
                action.PerformAction();
            }
        }
        yield return new WaitUntil(() => !player.runningRoutine);
        running = false;
    }
}
