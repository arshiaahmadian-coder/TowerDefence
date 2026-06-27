using UnityEngine;

public class Builder : MonoBehaviour
{
    public static BaseTile selectedTile;

    public static void Build(GameObject buildingPrefab)
    {
        if (selectedTile != null) selectedTile.Build(buildingPrefab);
    }
}
