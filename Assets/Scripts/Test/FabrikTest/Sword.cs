using System;

public class Sword : ISword
{
    public float speed = 4;

    void ISword.Sword()
    {
        throw new NotImplementedException();
    }

    //void ISword.Sword(float speed)
    //{
    //    this.speed = speed;
    //}
}