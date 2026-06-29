using UnityEngine;

public class BaseBuilding : MonoBehaviour
{
    public BuildingData data;
    public BaseEnemy target;

    private void Start()
    {
        Instantiate();
    }

    private void Update()
    {
        ProcessEveryFrame();
    }

    public virtual void Instantiate()
    {
        // TODO: cost building cost
    }

    public virtual void ProcessEveryFrame() { }
}