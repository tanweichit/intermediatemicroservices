﻿using Catalog.Repositories;
using Catalog.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICategoryRepository, CatetgoryInMemoryRepo>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductInMemoryRepo>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Catalog Module");
app.MapControllers();
app.Run();