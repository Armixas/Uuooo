using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAiAction : AiAction
{
    [Header("Agent")]
    [SerializeField]
    private float agentStoppingDistance = 2f;

    [Header("Controller")]
    [SerializeField]
    private float controllerStoppingDistance = 1f;


    [SerializeField]
    private float angleTreshold = 20f;

    [SerializeField]
    private float moveSmoothing = 0.5f;

    [SerializeField]
    private float mrotationSmoothing = 0.5f;

    public override void UpdateAction(AiController controller)
    {
        var controllerTransform = controller.transform;
        var controllerDirection = controllerTransform.forward;
        var controllerPosition = controllerTransform.position;

        var agent = controller.NavMeshAgent;
        var agentPosition = agent.nextPosition;

        var directionToAgent = GetDirection(controllerPosition, agentPosition);
        var distanceToAgent = GetDistance(controllerPosition, agentPosition);
        var angleToAgent = GetAngle(controllerDirection, directionToAgent);

        UpdateStopped(agent, distanceToAgent);
        UpdateMovement(controller, distanceToAgent, angleToAgent);
        UpdateRotation(controller, angleToAgent, directionToAgent);
    }

    private void UpdateRotation(AiController controller, float angleToAgent, Vector3 direction)
    {
        var targetAxis = controller.TargetAxis;
        //blogas
        var dot = Vector3.Dot(controller.transform.right, direction);

        targetAxis.x = Mathf.Sign(dot) * GetXAxis(angleToAgent);

        controller.TargetAxis = targetAxis;
    }

    private float GetXAxis(object angle)
    {
        throw new NotImplementedException();
    }

    private void UpdateMovement(AiController controller, float distanceToAgent, float angleToAgent)
    {
        var targetAxis = controller.TargetAxis;
        targetAxis.y = 0f;

        if (distanceToAgent > controllerStoppingDistance && angleToAgent <= angleTreshold) 
        {
            targetAxis.y = GetYAxis(distanceToAgent);
        }
        controller.TargetAxis = targetAxis;
    }

    private float GetYAxis(float distanceToAgent)
    {
        throw new NotImplementedException();
    }

    private void UpdateStopped(NavMeshAgent agent, float distanceToAgent)
    {
        agent.isStopped = distanceToAgent > agentStoppingDistance;
    }

    private float GetAngle(Vector3 controllerDirection, float directionToAgent)
    {
        throw new NotImplementedException();
    }

    private float GetDistance(Vector3 controllerPosition, Vector3 agentPosition)
    {
        throw new NotImplementedException();
    }

    private object GetDirection(Vector3 controllerPosition, Vector3 agentPosition)
    {
        throw new NotImplementedException();
    }

    public override void UpdateActionGizmos(AiController controller)
    {
        var agent = controller.NavMeshAgent;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(agent.nextPosition, 0.25f);

        Gizmos.color= Color.green;
        Gizmos.DrawSphere(agent.destination, 0.25f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
