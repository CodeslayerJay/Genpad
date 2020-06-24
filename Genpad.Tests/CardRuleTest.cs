using Genpad.Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Genpad.Engine.Rules;
using Xunit;

namespace Genpad.Tests
{
    
    public class CardRuleTest
    {

        private int _cardIdCounter = 1;

        [Fact]
        public void WhenNull_Returns_False()
        {
            Card card = null;
            CardRules cardRules = new CardRules(card);

            var result = cardRules.IsValid();

            Assert.False(result);
        }

        [Fact]
        public void WhenCard_ChangesToNull_Returns_False()
        {
            Card card = BuildCard(); 
            CardRules cardRules = new CardRules(card);
            card = null;

            var result = cardRules.IsValid();

            Assert.False(result);
        }

        [Fact]
        public void WhenTitle_IsNull_Returns_False()
        {
            Card card = BuildCard();
            CardRules cardRules = new CardRules(card);

            var result = cardRules.IsValid();

            Assert.False(result);
        }

        [Fact]
        public void WhenTitle_IsEmpty_Returns_False()
        {
            Card card = BuildCard("");
            CardRules cardRules = new CardRules(card);

            var result = cardRules.IsValid();

            Assert.False(result);
        }

        [Fact]
        public void WhenTitle_GreaterThanAllowedChars_Returns_False()
        {
            Card card = BuildCard(GenerateRandomString(200), "Test");
            CardRules cardRules = new CardRules(card);

            var result = cardRules.IsValid();

            Assert.False(result);
        }



        [Fact]
        public void WhenNote_IsNull_Return_False()
        {
            Card card = BuildCard("Test", null);
            CardRules cardRules = new CardRules(card);

            var result = cardRules.IsValid();

            Assert.False(result);
        }

        [Fact]
        public void WhenNote_IsGreaterThanAllowedChars_Return_False()
        {
            Card card = BuildCard("Test", GenerateRandomString(5000));
            CardRules cardRules = new CardRules(card);

            var result = cardRules.IsValid();

            Assert.False(result);
        }

        [Fact]
        public void WhenCard_IsValid_Returns_True()
        {
            Card card = BuildCard("Test", GenerateRandomString(300));
            CardRules cardRules = new CardRules(card);

            var result = cardRules.IsValid();

            Assert.True(result);
        }

        private Card BuildCard(string title = null, string note = null)
        {
            Card card = new Card
            {
                Id = _cardIdCounter++,
                Title = title,
                Note = note,
                CreatedAt = DateTime.Now
            };

            return card;
        }

        private string GenerateRandomString(int length = 10)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            return str_build.ToString();
        }
    }
}
