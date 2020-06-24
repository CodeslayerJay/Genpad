using System.Collections.Generic;

namespace Genpad.Engine.Types
{
    public interface ICommandResult
    {
        IEnumerable<CommandResultErrorModel> Errors { get; }

        void AddError(CommandResultErrorModel errorModel);
        void AddError(string errorMsg);
        bool IsValid();
    }
}