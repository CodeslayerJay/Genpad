using Genpad.Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genpad.Engine.Rules
{
    public class CardRules
    {
        public RuleResult RuleResult { get; }
        private Card _cardToTest;
        private const int NOTE_ALLOWED_LENGTH = 1000;
        private const int TITLE_ALLOWED_LENGTH = 100;

        public CardRules(Card cardToTest)
        {
            RuleResult = new RuleResult();
            _cardToTest = cardToTest;

            IsValid();
        }

        public bool IsValid()
        {
            return IsValid(_cardToTest);
        }

        public bool IsValid(Card cardToTest)
        {
            _cardToTest = cardToTest;

            CheckCardIsNull();
            CheckTitleIsNullOrEmpty();
            CheckTitleIsGreaterThanOrEqualToAllowedLength();
            CheckNoteIsNullOrEmpty();
            CheckNoteIsGreaterThanOrEqualToAllowedLength();

            return RuleResult.IsValid();
        }

        private void CheckCardIsNull()
        {
            if (_cardToTest == null) RuleResult.AddError("Card", "Card cannot be null.");
        }

        private void CheckTitleIsNullOrEmpty()
        {
            if(_cardToTest != null && String.IsNullOrEmpty(_cardToTest.Title)) 
            {
                RuleResult.AddError("Title", "Title cannot be null or empty.");
            }
            
        }

        private void CheckTitleIsGreaterThanOrEqualToAllowedLength()
        {
            if (_cardToTest != null && String.IsNullOrEmpty(_cardToTest.Title) == false)
            {
                if (_cardToTest.Title.Length >= TITLE_ALLOWED_LENGTH) RuleResult.AddError("Title", $"Title has to be less than or equal to {TITLE_ALLOWED_LENGTH}.");
            }

        }

        private void CheckNoteIsNullOrEmpty()
        {
            if (_cardToTest != null && String.IsNullOrEmpty(_cardToTest.Note))
            {
                RuleResult.AddError("Note", "Note cannot be null or empty.");
            }

        }

        private void CheckNoteIsGreaterThanOrEqualToAllowedLength()
        {
            if (_cardToTest != null && String.IsNullOrEmpty(_cardToTest.Note) == false)
            {
                if (_cardToTest.Note.Length >= NOTE_ALLOWED_LENGTH) RuleResult.AddError("Note", $"Note has to be less than or equal to {NOTE_ALLOWED_LENGTH}.");
            }

        }

    }
}
