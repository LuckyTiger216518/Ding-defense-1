using UnityEngine;

public class BuildManager : MonoBehaviour
{

    //En m�de at senere kunne kalde p� BuildManager, uden at skulle have alle tiles ind over
    public static BuildManager instance;

    /*Inden scriptet starter, bliver BuildManager puttet ind i en variable, som kan blive refferet 
     til overalt, p� et senere tidspunkt*/

    private void Awake()
    {
        instance = this;
    }

    //Vores standard t�rn
    public GameObject standardTowerPrefab;

    //Vi s�tter vores towerToBuild til at v�re vores standTowerPrefab
    private void Start()
    {
        towerToBuild = standardTowerPrefab;
    }

    //Det t�rn vi vil bygge
    private GameObject towerToBuild;

    //En m�de at kalde p� det t�rn, som vi gerne vil bygge
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}
