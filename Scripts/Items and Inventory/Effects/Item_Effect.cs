
using UnityEngine;

public class Item_Effect : ScriptableObject
{
    public virtual void ExecuteEffect(Transform _enemyPos)
    {
        Debug.Log("Effect executed!");
    }
}
