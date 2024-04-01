﻿using Microsoft.EntityFrameworkCore;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using StockApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Data.Repositories
{

    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _categoryContext;

        //construtor
        public CategoryRepository(ApplicationDbContext context) 
        {
            _categoryContext = context;//_ objeto local de configuração privado
        }

        public async Task<Category> Create(Category category)
        {
            _categoryContext.Categories.Add(category);
            await _categoryContext.SaveChangesAsync(); 
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _categoryContext.Categories.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Remove(Category category)
        {
            _categoryContext.Categories.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetById(int? id)
        {
            var category = await _categoryContext.Categories.FindAsync(id);
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.OrderBy(c => c.Name).ToListAsync();
        }


    }
}
