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

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    //Bliver kaldt n�r du trykker p� et tile
    private void OnMouseDown()
    {
        //Hvis der allerede er et t�rn p� tilen, s� sker der ikke noget
        if (tower != null)
        {
            return;
        }

        //Kalder p� vores tower i et buildmanager scriptet
        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();

        //Bygger vores t�rn p� vores nuv�rrende placering
        tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
    }

    //K�rer scriptet hver gang musen g�r ind i et tiles' collider
    private void OnMouseEnter()
    {
        //�ndre farven p� vores tile til hoverColor
        rend.material.color = hoverColor;
    }

    //�ndre farven tilbage til startColor, hver gang musen g�r ud af et tiles' collider
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
