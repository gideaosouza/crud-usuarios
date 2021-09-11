  
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome).NotNull().WithMessage("O Campo não deve ser Nulo")
              .NotEmpty().WithMessage("O Campo não deve ser vazio")
              .MaximumLength(200).WithMessage("O Campo não deve ter mais de 200 caracteres")
              .MinimumLength(2).WithMessage("Provavelmente esse campo está faltando dígitos");

            RuleFor(c =>c.EscolaridadeId)
              .NotNull().WithMessage("É necessário selecionar alguma escolaridade")
              .NotEmpty().WithMessage("É necessário selecionar alguma escolaridade")
              .GreaterThanOrEqualTo(0).WithMessage("É necessário selecionar alguma escolaridade");

            RuleFor(c=>c.DataNascimento)
              .NotNull().WithMessage("É necessário informar a data de nascimento")
              .LessThanOrEqualTo(DateTime.Today)
              .WithMessage("Data futura é inválida");

            RuleFor(c=>c.Email)
            .NotEmpty().WithMessage("Campo não pode estar vazio")
            .EmailAddress().WithMessage("Email inválido")            
            .MaximumLength(200).WithMessage("O Campo não deve ter mais de 200 caracteres");

        }
    }
}