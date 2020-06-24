using AutoMapper;
using Genpad.Data;
using Genpad.Data.DataModels;
using Genpad.DTOs;
using Genpad.Engine.Models;
using Genpad.Engine.Rules;
using Genpad.Engine.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Genpad.Services
{
    public class CardService : ICardService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CardService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ICommandResult> AddCard(CardDTO cardToAdd)
        {
            var card = MapToCard(cardToAdd);
            var ruleResult = ValidateCard(card);
            if (ruleResult.IsValid() == false)
                return ruleResult;

            _dataContext.Cards.Add(GetCardAsExtended(card));
            await _dataContext.SaveChangesAsync();

            return ruleResult;
        }

        private Card MapToCard(CardDTO cardToMap)
        {
            return _mapper.Map<Card>(cardToMap);
        }

        private ICommandResult ValidateCard(Card cardToValidate)
        {
            var cardRules = new CardRules(cardToValidate);
            return cardRules.RuleResult;
        }

        private CardExtended GetCardAsExtended(Card cardToExtend)
        {
            CardExtended cardExtended = new CardExtended
            {
                UserId = "TESTING123",
                CreatedAt = cardToExtend.CreatedAt,
                Title = cardToExtend.Title,
                Note = cardToExtend.Note
            };

            return cardExtended;
        }
    }
}
