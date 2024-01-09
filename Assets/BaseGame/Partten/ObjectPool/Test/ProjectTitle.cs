using UnityEngine;

public class ProjectTitle : PooledObject
{
    [SerializeField] private float prjVelocity;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lifeTime;
    private float timer;

    private void OnEnable()
    {
        rb.velocity = new Vector2 (prjVelocity,0);
        timer = lifeTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) 
        {
            Release();
        }
    }
}
