using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CSharpWpf.Core.Messages
{
    public class ProgramExitMessage : ValueChangedMessage<bool>
    {
        public ProgramExitMessage(bool value) : base(true)
        {

        }
    }
}
