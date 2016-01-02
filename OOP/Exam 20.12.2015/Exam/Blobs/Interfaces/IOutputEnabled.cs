namespace Blobs.Interfaces
{
    using Events;

    public interface IOutputEnabled
    {
        event OutputMessageEventHandler OutputMessage;
    }
}
