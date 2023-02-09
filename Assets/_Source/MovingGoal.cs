using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGoal : IPlayerGoal
{
    private Transform _bodyToMove;
    public MovingGoal(Transform bodyToMove)
    {
        _bodyToMove = bodyToMove;
    }
    public void FulfillGoal(ref Deque<IAction> ActionQueue)
    {
        var action = new MoveAction
        {
            MovedFrom = new Vector2(_bodyToMove.position.x, _bodyToMove.position.y)
        };
        _bodyToMove.position = new Vector2(
            Camera.allCameras[0].ScreenToWorldPoint(Input.mousePosition).x,
            Camera.allCameras[0].ScreenToWorldPoint(Input.mousePosition).y);
        ActionQueue.AddLast(action);
    }
}
