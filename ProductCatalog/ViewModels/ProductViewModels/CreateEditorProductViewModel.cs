﻿using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.ViewModels.ProductViewModels
{
    public class CreateEditorProductViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Title, 120, "Title", "O título deve conter até 120 caracteres.")
                    .HasMinLen(Title, 3, "Title", "O título deve ter no mínimo 3 caracteres.")
                    .IsGreaterThan(Price, 0, "Price", "O preço deve ser maior que zero.")
            );
        }
    }
}
