using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public delegate void FulfillTheDream(Goals goal);
    public event FulfillTheDream MoveGoalInvoked;
    public event FulfillTheDream CreateGoalInvoked;
    public event FulfillTheDream UndoLastDream;
    [SerializeField] Camera _currentCamera;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            MoveGoalInvoked.Invoke(Goals.Move);
        if (Input.GetKeyDown(KeyCode.Mouse1))
            CreateGoalInvoked.Invoke(Goals.Create);
        if (Input.GetKeyDown(KeyCode.Mouse2))
            UndoLastDream.Invoke(Goals.Undo);
    }
}
