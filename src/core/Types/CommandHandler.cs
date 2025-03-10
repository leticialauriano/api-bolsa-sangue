using core.Repository.UnitOfWork;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace core.Types
{
    public abstract class CommandHandler
    {
        protected ValidationResult Notification;

        protected CommandHandler()
        {
            Notification = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            var error = new ValidationFailure(string.Empty, mensagem);
            Notification.Errors.Add(error);
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
        {
            if (!await uow.Commit())
                AddError(message);

            return Notification;
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow)
        {
            return await Commit(uow, Messages.Validators.Messages.Erros.CommitError).ConfigureAwait(false);
        }
    }
}