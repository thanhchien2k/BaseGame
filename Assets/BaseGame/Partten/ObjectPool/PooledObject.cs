using BaseGame.ObjectPool;
using UnityEngine;

public class PooledObject: MonoBehaviour
{
    private PoolBase pool;
    public PoolBase Pool { get { return pool; } set { pool = value; } }

    public void Release()
    {
        pool.ReturnToPool(this);
    }
}
