using UnityEngine;

public class BuildManager : MonoBehaviour
{

    //En m�de at senere kunne kalde p� BuildManager, uden at skulle have alle tiles ind over
    public static BuildManager instance;
    public int towerCost = 50;                  // The cost of a tower
    private MoneyManager moneyManager;

    /*Inden scriptet starter, bliver BuildManager puttet ind i en variable, som kan blive refferet 
     til overalt, p� et senere tidspunkt*/

    private void Awake()
    {
        instance = this;
    }

    //Vores standard t�rn
    public GameObject standardTowerPrefab;

    //Vores t�rn til flyvende enemies
    public GameObject flyingTowerPrefab;

    //Vores t�rn der slower enemies
    public GameObject slowingTowerPrefab;

    //Vi s�tter vores towerToBuild til at v�re vores standTowerPrefab
    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    //Det t�rn vi vil bygge
    private GameObject towerToBuild;

    //En m�de at kalde p� det t�rn, som vi gerne vil bygge
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }
}
