using Login.Data.Generic;

namespace Login.Services.EmailSenderService
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(Message message);
    }
}
