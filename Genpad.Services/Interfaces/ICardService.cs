
using Genpad.Data.DTO;
using Genpad.Engine.Types;
using System.Threading.Tasks;

namespace Genpad.Services.Interfaces
{
    public interface ICardService
    {
        Task<ICommandResult> AddCard(CardDTO cardToAdd);
    }
}