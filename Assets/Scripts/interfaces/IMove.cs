public interface IMove 
{
    float Speed { get; }
    void Move(float horizontal, float deltaTime);
}
