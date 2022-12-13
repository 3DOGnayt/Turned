public interface IJump
{
    float Speed { get; }
    void Jump(float vertical, float deltaTime);
}
