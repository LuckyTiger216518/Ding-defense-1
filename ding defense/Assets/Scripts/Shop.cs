using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    //Vælger vores standard tower til at bygge
    public void PurchaseStandardTower()
    {
        buildManager.SetTowerToBuild(buildManager.standardTowerPrefab);
    }

    //Vælger vores flying tower til at bygge
    public void PurchaseFlyingTower()
    {
        buildManager.SetTowerToBuild(buildManager.flyingTowerPrefab);
    }

    //Vælger vores slowing tower til at bygge
    public void PurchaseSlowingTower()
    {
        buildManager.SetTowerToBuild(buildManager.slowingTowerPrefab);
    }
}
