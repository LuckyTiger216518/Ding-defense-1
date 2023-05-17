using UnityEngine;

public class BuildManager : MonoBehaviour
{

    //En måde at senere kunne kalde på BuildManager, uden at skulle have alle tiles ind over
    public static BuildManager instance;
   
    //pris på tower sådan de connectes fra build manageren og tiles scriptet
    public int towerCost = 50;                  

    //skaber moneymaneger at arbejde med i dette script
    private MoneyManager moneyManager;

    public UpgradeUI upgradeUI;

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

    private Tiles selectedTile;

    //Vi sætter vores towerToBuild til at være vores standTowerPrefab
    private void Start()
    {
        //finder manageren i projektet (vores gamemanager)
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    //Det tårn vi vil bygge
    private GameObject towerToBuild;

    //En måde at kalde på det tårn, som vi gerne vil bygge
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    //Gør at vi kun kan vælge et tårn til at bygge eller et tile (i forhold til upgrades)
    public void SelectTile(Tiles tile)
    {
        if (selectedTile == tile)
        {
            DeselectTile();
            return;
        }
        selectedTile = tile;
        towerToBuild = null;

        upgradeUI.SetTarget(tile);
    }

    public void DeselectTile()
    {
        selectedTile = null;
        upgradeUI.Hide();
    }

    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
        selectedTile = null;

        DeselectTile();
    }
}
