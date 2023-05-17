using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    //Gør så at vi kan slå upgrade knappen til og fra
    public GameObject ui;

    private Tiles target;

    public void SetTarget(Tiles _target)
    {
        target = _target;

        transform.position = target.transform.position;

        ui.SetActive(true);
    }

    //er med til at gemme ui
    public void Hide()
    {
        ui.SetActive(false);
    }
}
