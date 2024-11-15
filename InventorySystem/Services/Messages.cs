using CommunityToolkit.Mvvm.Messaging.Messages;

namespace InventorySystem.Services;

public class RefreshMessage : ValueChangedMessage<bool>
{
    public RefreshMessage(bool value) : base(value)
    {
    }
}
