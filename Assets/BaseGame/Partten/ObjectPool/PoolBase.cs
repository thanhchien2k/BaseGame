using System.Collections.Generic;
using UnityEngine;

namespace BaseGame.ObjectPool
{
    public class PoolBase: MonoBehaviour
    {
        // initial number of cloned objects
        [SerializeField] private uint initPoolSize;
        // pooledObject Prefabs
        [SerializeField] private PooledObject pooledObject;
        
        [SerializeField] private Transform root;

        private Stack<PooledObject> stackPooled;

        private void Start()
        {
            SetupPool();
            if(root == null) root = transform; 
        }
            
        private void SetupPool()
        {
            if (pooledObject == null) return;

            stackPooled = new ();
            PooledObject tempObj = null;

            for (int i = 0; i < initPoolSize; i++)
            {
                tempObj = Instantiate(pooledObject, root);
                tempObj.gameObject.SetActive(false);
                tempObj.Pool = this;
                stackPooled.Push(tempObj);
            }
        }

        public PooledObject GetObject()
        {
            if (pooledObject == null) return null;

            if(stackPooled.Count == 0)
            {
                PooledObject newObj = Instantiate(pooledObject, root);
                newObj.Pool = this;
                return newObj;
            }

            PooledObject stackObj = stackPooled.Pop();
            stackObj.gameObject.SetActive(true);
            return stackObj;
        }

        public void ReturnToPool(PooledObject pooledObject)
        {
            stackPooled.Push(pooledObject);
            pooledObject.gameObject.SetActive(false);
        }
    }
}
