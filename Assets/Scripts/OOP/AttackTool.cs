using UnityEngine;

public abstract class AttackTool : MonoBehaviour
{
    [SerializeField]
    protected int _damage;
    public abstract void Initialize();
    public abstract void Attack();
}
