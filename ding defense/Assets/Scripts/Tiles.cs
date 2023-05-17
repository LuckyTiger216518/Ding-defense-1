using UnityEngine;

public class Tiles : MonoBehaviour
{
    //Den farve som vores tiles skifter til, når musen er over dem
    public Color hoverColor;

    //Gemmer den oprindelige farve på vores tile
    private Color startColor;

    /*Gemmer vores renderer i starten af spillet, så vi ikke behøver at finde den hver gang,
     vi skal bruge den*/
    private Renderer rend;

    //Det nuværrende tårn, som står på vores tile
    private GameObject tower;

    //Hvad towers skal koste 
    public int towerCost = 50;

    //skaber så vi kan arbejde med moneymanager
    private MoneyManager moneyManager;

    BuildManager buildManager;

    private void Start()
    {
        //finder manageren i projektet (vores gamemanager)
        moneyManager = FindObjectOfType<MoneyManager>();

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    //Bliver kaldt når du trykker på et tile
    private void OnMouseDown()
    {

        //Hvis vores buildmanager er nul, så skal der ikke ske noget i det her script
        if (buildManager.GetTowerToBuild() == null)
        {
            return;
        }


        //checker om der er penge på vores manager og hvis der er penge og det ikke er mindre end kosten så kan du kører koden og hermed 
        //fjerne penge fra vores manager og placere tårne

        if (moneyManager != null && moneyManager.currentMoney >= towerCost)
        {
            moneyManager.DecreaseMoney(towerCost);

        }
            //Hvis der allerede er et tårn på tilen, så sker der ikke noget
            if (tower != null)
        {

            return;
        }

        //Kalder på vores tower i et buildmanager scriptet
        GameObject towerToBuild = buildManager.GetTowerToBuild();

        //Bygger vores tårn på vores nuværrende placering
        tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);

    }

    //Kører scriptet hver gang musen går ind i et tiles' collider
    private void OnMouseEnter()
    {
        //Farven skal kun skiftes på tiles, hvis der er valgt et tårn
        if (buildManager.GetTowerToBuild() == null)
        {
            return;
        }

        //Ændre farven på vores tile til hoverColor
        rend.material.color = hoverColor;
    }

    //Ændre farven tilbage til startColor, hver gang musen går ud af et tiles' collider
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
