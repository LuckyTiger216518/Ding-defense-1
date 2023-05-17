using UnityEngine;

public class BuildManager : MonoBehaviour
{

    //En måde at senere kunne kalde på BuildManager, uden at skulle have alle tiles ind over
    public static BuildManager instance;
    public int towerCost = 50;                  // The cost of a tower
    private MoneyManager moneyManager;

    /*Inden scriptet starter, bliver BuildManager puttet ind i en variable, som kan blive refferet 
     til overalt, på et senere tidspunkt*/

    private void Awake()
    {
        instance = this;
    }

    //Vores standard tårn
    public GameObject standardTowerPrefab;

    //Vores tårn til flyvende enemies
    public GameObject flyingTowerPrefab;

    //Vores tårn der slower enemies
    public GameObject slowingTowerPrefab;

    //Vi sætter vores towerToBuild til at være vores standTowerPrefab
    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    //Det tårn vi vil bygge
    private GameObject towerToBuild;

    //En måde at kalde på det tårn, som vi gerne vil bygge
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }
}
