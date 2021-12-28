public interface IPoolable 
{
    bool IsActive { get; }
    void Enable();
    void Disable();
}
