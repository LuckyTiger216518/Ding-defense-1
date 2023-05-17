using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int upgradeCost = 100;

    private Bullet bullet;
    private MoneyManager moneyManager;

    private void Start()
    {
        bullet = bulletPrefab.GetComponent<Bullet>();
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    public void Upgrade()
    {
        if (moneyManager.CanAfford(upgradeCost))
        {
            bullet.SetDamage(bullet.GetDamage() + 1);
            moneyManager.SpendMoney(upgradeCost);
            Debug.Log("Tower upgraded! Damage increased to: " + bullet.GetDamage());
        }
        else
        {
            Debug.Log("Insufficient funds to upgrade tower.");
        }
    }
}
