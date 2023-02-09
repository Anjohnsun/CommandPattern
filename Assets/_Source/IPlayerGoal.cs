using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerGoal
{
    public void FulfillGoal(ref Deque<IAction> ActionQueue);
}
