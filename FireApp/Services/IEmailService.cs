using FireApp.Dtos;

namespace FireApp.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
