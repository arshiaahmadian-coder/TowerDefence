using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public EnemyData data;
    public int currentWaypoint = 0;
    private void Start()
    {
        Initialisation();
    }

    private void Update()
    {
        Movement();
    }

    public virtual void Initialisation() { }

    public virtual void Movement()
    {
        Transform target = WaypointManager.instance.waypoints[currentWaypoint];

        // move
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            data.speed * Time.deltaTime
        );

        // rotate | look at next waypoint
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle + data.rotationOffset);
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            data.rotationSpeed * Time.deltaTime
        );

        // reach to waypoint
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypoint++;

            if (currentWaypoint >= WaypointManager.instance.waypoints.Count)
            {
                // TODO: decrease player health
                EnemySpawner.instance.RemoveEnemyFromList(this);
                Destroy(gameObject);
            }
        }
    }
}
