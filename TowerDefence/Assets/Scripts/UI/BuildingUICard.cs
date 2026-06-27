using UnityEngine;

public class BuildingUICard : MonoBehaviour
{
    [SerializeField] private GameObject buildingPrefab;

    public void OnClick()
    {
        // TODO: check if player have enughe gold
        Builder.Build(buildingPrefab);
        BuildingsListUI.instance.CloseMenu();
        // TODO: decrease player's gold
    } 
}
