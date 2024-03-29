﻿using System.ComponentModel.DataAnnotations;

namespace GestaoRestaurante.Api.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? NomeUsuario { get; set; }

        public Carrinho? Carrinho { get; set; }
    }
}