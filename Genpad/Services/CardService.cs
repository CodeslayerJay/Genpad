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

namespace Genpad.Services
{
    public class CardService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CardService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public ICommandResult AddCard(CardDTO cardToAdd)
        {
            var card = MapToCard(cardToAdd);
            var ruleResult = ValidateCard(card);
            if (ruleResult.IsValid() == false)
                return ruleResult;

            _dataContext.Cards.Add(GetCardAsExtended(card));
            _dataContext.SaveChanges();

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
            CardExtended cardExtended = cardToExtend as CardExtended;
            cardExtended.UserId = "TESTING123";

            return cardExtended;
        }
    }
}
