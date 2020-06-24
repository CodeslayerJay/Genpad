using System;
using System.Collections.Generic;
using System.Text;

namespace Genpad.Engine.Types
{
    public class CommandResult : ICommandResult
    {
        private List<CommandResultErrorModel> _errors;
        public IEnumerable<CommandResultErrorModel> Errors => _errors;

        public CommandResult()
        {
            _errors = new List<CommandResultErrorModel>();
        }

        public bool IsValid()
        {
            return _errors.Count == 0;
        }

        public virtual void AddError(string errorMsg)
        {
            if (String.IsNullOrEmpty(errorMsg)) throw new ArgumentNullException(nameof(errorMsg));

            _errors.Add(new CommandResultErrorModel { ErrorMsg = errorMsg });
        }

        public void AddError(CommandResultErrorModel errorModel)
        {
            if (errorModel == null) throw new ArgumentNullException(nameof(errorModel));
            if (String.IsNullOrEmpty(errorModel.ErrorMsg)) throw new ArgumentException("Error msg cannot be null or empty.");

            _errors.Add(errorModel);
        }
    }

    public interface ICommandResultErrorModel
    {
        string ErrorMsg { get; set; }
    }

    public class CommandResultErrorModel : ICommandResultErrorModel
    {
        public string ErrorMsg { get; set; }
    }
}
