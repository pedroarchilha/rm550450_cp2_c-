﻿using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome nao pode ficar vazio.");
            RuleFor(x => x.CNPJ).NotEmpty().WithMessage("O CNPJ nao pode ficar vazio.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email inserido esta errado.");
        }
    }
}
