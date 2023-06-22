using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AIState", menuName ="Lec11/AIState")]
public class AiState : ScriptableObject
{
    private List<AiAction> actions;
    // Start is called before the first frame update
    public void UpdateStateGizmos(AiController controller)
    {
        foreach (var action in actions)
        {
            action.UpdateActionGizmos(controller);
        }
    }

    public void UpdateState(AiController controller)
    {
        foreach(var action in actions) { 
        
            action.UpdateAction(controller);
        }
    }
}
