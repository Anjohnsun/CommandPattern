using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingGoal : IPlayerGoal
{
    private GameObject _prefabToCreate;

    public CreatingGoal(GameObject prefab)
    {
        _prefabToCreate = prefab;
    }
    public void FulfillGoal(ref Deque<IAction> ActionQueue)
    {
        var obj = Object.Instantiate(_prefabToCreate, new Vector2(
            Camera.allCameras[0].ScreenToWorldPoint(Input.mousePosition).x,
            Camera.allCameras[0].ScreenToWorldPoint(Input.mousePosition).y), new Quaternion());
        var action = new CreateAction();
        action.CreatedObject = obj;
        ActionQueue.AddLast(action);
    }
}
