using UnityEngine;
using UnityEngine.AI;

public class PauseManager : MonoBehaviour
{
    public PlayerControl playerControl;
    public NavMeshAgent agent;

    public void ManagePause()
    {
        playerControl.enabled = !playerControl.enabled;
        agent.enabled = !agent.enabled;
    }
}
