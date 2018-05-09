using System.Drawing;

namespace HearthstoneHotkeys.IO
{
    public interface ITransformable
    {
        Point Transform(Rectangle rectangle);
    }
}
