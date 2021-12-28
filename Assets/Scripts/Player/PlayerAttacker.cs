using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField]
    private AttackTool _attackToolPrefab;
    [SerializeField]
    private Transform _attackToolPoint;
    private AttackTool _attackTool;
    public void Initialize()
    {
        _attackTool = Instantiate(_attackToolPrefab, _attackToolPoint.position, Quaternion.identity, transform);
        _attackTool.Initialize();
    }
 
    public void Attack()
    {
        _attackTool.Attack();
    }    
}
