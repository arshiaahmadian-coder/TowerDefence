using UnityEngine;

public class BuildingsListUI : MonoBehaviour
{
    [SerializeField] private GameObject buildingsCanv;
    public static BuildingsListUI instance;
    public static bool isOpen = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CloseMenu();
    }

    public void OpenMenu()
    {
        buildingsCanv.SetActive(true);
        isOpen = true;
    }

    public void CloseMenu()
    {
        buildingsCanv.SetActive(false);
        isOpen = false;
    }
}
