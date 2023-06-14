﻿using System;
using Catalog.Entities;
using Catalog.Repositories;

namespace Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Create(Category category)
        {
            // check if the name is not empty
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new CategoryNameEmptyException();
            }

            // make sure the category is not already exists
            var exists = _categoryRepository.CategoryNameIsExist(category.Name);
            if (exists)
            {
                throw new CategoryAlreadyExistsException(category.Name);
            }
            await _categoryRepository.Add(category);            
        }
    }
}
