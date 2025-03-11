using NServiceBus;

namespace InspectionCheckLogin.Messages
{
    public class LoginRequest : IMessage
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class LoginResponse : IMessage
    {
        public string Email { get; set; }
    }

}
