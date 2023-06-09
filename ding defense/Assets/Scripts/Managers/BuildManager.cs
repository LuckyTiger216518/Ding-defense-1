using UnityEngine;

public class BuildManager : MonoBehaviour
{

    //En m�de at senere kunne kalde p� BuildManager, uden at skulle have alle tiles ind over
    public static BuildManager instance;
   
    //pris p� tower s�dan de connectes fra build manageren og tiles scriptet
    public int towerCost = 50;                  

    //skaber moneymaneger at arbejde med i dette script
    private MoneyManager moneyManager;

    public UpgradeUI upgradeUI;

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

    private Tiles selectedTile;

    //Vi s�tter vores towerToBuild til at v�re vores standTowerPrefab
    private void Start()
    {
        //finder manageren i projektet (vores gamemanager)
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    //Det t�rn vi vil bygge
    private GameObject towerToBuild;

    //En m�de at kalde p� det t�rn, som vi gerne vil bygge
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    //G�r at vi kun kan v�lge et t�rn til at bygge eller et tile (i forhold til upgrades)
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
