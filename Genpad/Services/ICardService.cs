using Genpad.DTOs;
using Genpad.Engine.Types;
using System.Threading.Tasks;

namespace Genpad.Services
{
    public interface ICardService
    {
        Task<ICommandResult> AddCard(CardDTO cardToAdd);
    }
}