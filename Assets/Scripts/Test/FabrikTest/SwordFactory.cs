public class SwordFactory
{
    public static ISword CreateSword(TypeSword type)
    {
        switch (type)
        {
            case TypeSword.Sword: return new Sword();
            case TypeSword.BigSword: return new BigSword();
            case TypeSword.ExSword: return new ExSword();
            default: return new Sword();
        }

        //var sw = SwordFactory.CreateSword(TypeSword.Sword);
        ////sw.Sword();
    }
}