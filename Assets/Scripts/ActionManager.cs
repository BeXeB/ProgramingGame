using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    [SerializeField] List<Action> actionsToPerform;
    PlayerMovement player;
    bool performing;

    private void Start()
    {
        player = PlayerManager.instance.player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformActions();
        }
    }

    public void PerformActions()
    {
        if (!performing)
        {
            StartCoroutine(PerformActionsBehaviour());
        }
    }

    IEnumerator PerformActionsBehaviour()
    {
        performing = true;
        yield return new WaitUntil(() => !player.runningRoutine);
        foreach (Action action in actionsToPerform)
        {
            action.PerformAction();
            yield return new WaitUntil(() => !action.running);
        }
        performing = false;
    }
}
