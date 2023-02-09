using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoalRealizer : MonoBehaviour
{
    [SerializeField] private Transform _bodyToMove;
    [SerializeField] private GameObject _prefabToCreate;
    private PlayerGoalInvoker _goalInvoker;
    [SerializeField] InputSystem _inputSystem;

    private void Start()
    {
        _goalInvoker = new PlayerGoalInvoker(_prefabToCreate, _bodyToMove);
        _inputSystem.MoveGoalInvoked += FulfillGoal;
        _inputSystem.CreateGoalInvoked += FulfillGoal;
        _inputSystem.UndoLastDream += FulfillGoal;
    }

    private void FulfillGoal(Goals goal)
    {
        _goalInvoker.FulfillGoal(goal);
    }
}
