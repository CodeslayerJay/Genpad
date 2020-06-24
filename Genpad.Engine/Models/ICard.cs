using System;

namespace Genpad.Engine.Models
{
    public interface ICard
    {
        DateTime CreatedAt { get; set; }
        int Id { get; set; }
        string Note { get; set; }
        string Title { get; set; }
    }
}