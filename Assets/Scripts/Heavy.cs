public class Heavy : Enemy
{
    private int _speedModifier = 2;

    private Heavy()
    {
        Speed /= _speedModifier;
    }
}
