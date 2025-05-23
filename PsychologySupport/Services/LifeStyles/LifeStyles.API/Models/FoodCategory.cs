﻿namespace LifeStyles.API.Models;

public class FoodCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<FoodActivity> FoodActivities { get; set; }
}