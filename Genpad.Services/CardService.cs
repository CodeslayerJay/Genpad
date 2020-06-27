using AutoMapper;
using Genpad.Data;
using Genpad.Data.DTO;
using Genpad.Engine.Models;
using Genpad.Engine.Rules;
using Genpad.Engine.Types;
using Genpad.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Genpad.Services
{
    public class CardService : ServiceBase, ICardService
    {
        
        private readonly DataContext _dataContext;

        public CardService(DataContext dataContext)
        {
            _dataContext = dataContext;
            
        }

        public async Task<ICommandResult> AddCard(CardDTO cardToAdd)
        {
            var card = MapToCard(cardToAdd);
            var ruleResult = ValidateCard(card);
            if (ruleResult.IsValid() == false)
                return ruleResult;

            _dataContext.Cards.Add(GetCardDTO(card));
            await _dataContext.SaveChangesAsync();

            return ruleResult;
        }

        private Card MapToCard(CardDTO cardToMap)
        {
            return Mapper.Map<Card>(cardToMap);
        }

        private ICommandResult ValidateCard(Card cardToValidate)
        {
            var cardRules = new CardRules(cardToValidate);
            return cardRules.RuleResult;
        }

        private CardDTO GetCardDTO(Card card)
        {
            CardDTO cardDTO = new CardDTO
            {
                UserId = "TESTING123",
                CreatedAt = card.CreatedAt,
                Title = card.Title,
                Note = card.Note
            };

            return cardDTO;
        }
    }
}
