using UnityEngine;

public class Tiles : MonoBehaviour
{
    //Den farve som vores tiles skifter til, n�r musen er over dem
    public Color hoverColor;

    //Gemmer den oprindelige farve p� vores tile
    private Color startColor;

    /*Gemmer vores renderer i starten af spillet, s� vi ikke beh�ver at finde den hver gang,
     vi skal bruge den*/
    private Renderer rend;

    //Det nuv�rrende t�rn, som st�r p� vores tile
    private GameObject tower;

    //Hvad towers skal koste 
    public int towerCost = 50;

    //skaber s� vi kan arbejde med moneymanager
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

    //Bliver kaldt n�r du trykker p� et tile
    private void OnMouseDown()
    {

        //Hvis vores buildmanager er nul, s� skal der ikke ske noget i det her script
        if (buildManager.GetTowerToBuild() == null)
        {
            return;
        }


        //checker om der er penge p� vores manager og hvis der er penge og det ikke er mindre end kosten s� kan du k�rer koden og hermed 
        //fjerne penge fra vores manager og placere t�rne

        if (moneyManager != null && moneyManager.currentMoney >= towerCost)
        {
            moneyManager.DecreaseMoney(towerCost);

        }
            //Hvis der allerede er et t�rn p� tilen, s� sker der ikke noget
            if (tower != null)
        {

            return;
        }

        //Kalder p� vores tower i et buildmanager scriptet
        GameObject towerToBuild = buildManager.GetTowerToBuild();

        //Bygger vores t�rn p� vores nuv�rrende placering
        tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);

    }

    //K�rer scriptet hver gang musen g�r ind i et tiles' collider
    private void OnMouseEnter()
    {
        //Farven skal kun skiftes p� tiles, hvis der er valgt et t�rn
        if (buildManager.GetTowerToBuild() == null)
        {
            return;
        }

        //�ndre farven p� vores tile til hoverColor
        rend.material.color = hoverColor;
    }

    //�ndre farven tilbage til startColor, hver gang musen g�r ud af et tiles' collider
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
