public class Scout : Enemy
{
    private int _speedModifier = 2;

    private Scout()
    {
        Speed *= _speedModifier;
    }
}
