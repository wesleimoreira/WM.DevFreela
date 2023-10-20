﻿namespace WM.DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, decimal totalCost, string description, DateTime createdAt)
        {
            Id = id;
            Title = title;
            CreatedAt = createdAt;
            TotalCost = totalCost;
            Description = description;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public decimal TotalCost { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
