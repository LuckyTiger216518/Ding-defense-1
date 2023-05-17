using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    private Tiles target;

    public void SetTarget(Tiles _target)
    {
        target = _target;

        transform.position = target.transform.position;
    }
}
