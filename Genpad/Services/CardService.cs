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
        public ICommandResult AddCard(Card card)
        {
            var cardRules = new CardRules(card);

            if (cardRules.IsValid() == false)
                return cardRules.RuleResult;

            //TODO: Add Card To Collection

            return cardRules.RuleResult;
        }
    }
}
