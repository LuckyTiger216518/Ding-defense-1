using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    //V�lger vores standard tower til at bygge
    public void PurchaseStandardTower()
    {
        buildManager.SetTowerToBuild(buildManager.standardTowerPrefab);
    }

    //V�lger vores flying tower til at bygge
    public void PurchaseFlyingTower()
    {
        buildManager.SetTowerToBuild(buildManager.flyingTowerPrefab);
    }

    //V�lger vores slowing tower til at bygge
    public void PurchaseSlowingTower()
    {
        buildManager.SetTowerToBuild(buildManager.slowingTowerPrefab);
    }
}
