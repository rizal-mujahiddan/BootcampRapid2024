﻿using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public interface ICategory : ICrud<Category>
    {
        IEnumerable<Category> GetByCategoryName(string categoryName);
    }
}