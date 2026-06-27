using UnityEngine;

public class BaseTile : MonoBehaviour
{
    public bool hasBuilding = false;
    public GameObject building = null;

    public void Build(GameObject _building)
    {
        building = Instantiate(_building, transform.position, Quaternion.identity);
        hasBuilding = true;
    }
}
