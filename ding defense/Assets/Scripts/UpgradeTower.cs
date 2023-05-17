using UnityEngine;
using UnityEngine.UI;

public class UpgradeTower : MonoBehaviour
{
    public int upgradeCost = 100;
    public int damageIncrease = 1;
    public Bullet bullet;
    public MoneyManager moneyManager;

    private void Start()
    {
        Button upgradeButton = GetComponent<Button>();
        upgradeButton.onClick.AddListener(UpgradeTowerOnClick);
    }

    private void UpgradeTowerOnClick()
    {
        if (moneyManager.CanAfford(upgradeCost))
        {
            moneyManager.SpendMoney(upgradeCost);
            UpgradeBullet();
        }
        else
        {
            Debug.Log("Insufficient funds to upgrade the tower.");
        }
    }

    private void UpgradeBullet()
    {
        int currentDamage = bullet.GetDamage();
        int newDamage = currentDamage + damageIncrease;
        bullet.SetDamage(newDamage);
        Debug.Log("Tower upgraded. Bullet damage increased to " + newDamage + ".");
    }
}