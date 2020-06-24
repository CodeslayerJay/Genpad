using Genpad.Engine.Models;
using Genpad.Engine.Rules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genpad.Data.DbRules
{
    public static class DbConfigure
    {
        private static ModelBuilder _modelBuilder;

        public static void Configure(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            ConfigureCard();
        }

        private static void ConfigureCard()
        {
            var entity = _modelBuilder.Entity<Card>();

            entity.Property(q => q.Title).IsRequired(true).HasMaxLength(CardRules.TITLE_ALLOWED_LENGTH);
            entity.Property(q => q.Note).IsRequired(true).HasMaxLength(CardRules.NOTE_ALLOWED_LENGTH);
            entity.Property(q => q.CreatedAt).IsRequired(true).ValueGeneratedOnAdd();
        }
    }
}
