using AutoMapper;
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

        public CardService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ICommandResult AddCard(CardDTO cardToAdd)
        {
            var cardRules = new CardRules(_mapper.Map<Card>(cardToAdd));

            if (cardRules.IsValid() == false)
                return cardRules.RuleResult;

            //TODO: Add Card To Collection

            return cardRules.RuleResult;
        }
    }
}
