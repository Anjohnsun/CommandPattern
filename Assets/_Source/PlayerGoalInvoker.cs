using System.Collections;
using UnityEngine;

public class PlayerGoalInvoker
{
    private CreatingGoal _creatingGoal;
    private MovingGoal _movingGoal;
    private Transform _bodyToMove;

    private Deque<IAction> _goalsQueue;

    public PlayerGoalInvoker(GameObject prefab, Transform body)
    {
        _creatingGoal = new CreatingGoal(prefab);
        _movingGoal = new MovingGoal(body);
        _goalsQueue = new Deque<IAction>();
        _bodyToMove = body;
    }

    public void FulfillGoal(Goals nextGoal)
    {
        switch (nextGoal)
        {
            case Goals.Move:
                _movingGoal.FulfillGoal(ref _goalsQueue);
                break;
            case Goals.Create:
                _creatingGoal.FulfillGoal(ref _goalsQueue);
                break;
            case Goals.Undo:
                UndoLastGoal();
                break;
        }
    }

    private void UndoLastGoal()
    {
        var action = _goalsQueue.RemoveLast();
        if(action.GetType() == typeof(MoveAction))
        {
            MoveAction lastPos = (MoveAction)action;
            _bodyToMove.position = lastPos.MovedFrom;
        }
        if(action.GetType() == typeof(CreateAction))
        {
            CreateAction lastObj = (CreateAction)action;
            Object.Destroy(lastObj.CreatedObject);
        }
    }
}


public enum Goals 
{
    Move,
    Create,
    Undo
}

public interface IAction{}
public struct MoveAction : IAction
{
    public Vector2 MovedFrom;
}
public struct CreateAction : IAction
{
    public GameObject CreatedObject;
}
