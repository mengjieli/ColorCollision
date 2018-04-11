using lib;

public class GameVO
{
    public float Width;
    public float Height;
    public float PixelWidth;
    public float PixelHeight;

    //分数
    public IntValue score = new IntValue();

    //连击
    public IntValue combo = new IntValue();

    private static GameVO instance;

    public static GameVO Instance
    {
        get
        {
            if (instance ==  null)
            {
                instance = new GameVO();
            }
            return instance;
        }
    }
}