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

    //Vi sætter vores towerToBuild til at være vores standTowerPrefab
    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();

        towerToBuild = standardTowerPrefab;
    }

    //Det tårn vi vil bygge
    private GameObject towerToBuild;

    //En måde at kalde på det tårn, som vi gerne vil bygge
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}
