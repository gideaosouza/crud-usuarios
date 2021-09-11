  
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Validations
{
    public class EscolaridadeValidator : AbstractValidator<Escolaridade>
    {
        public EscolaridadeValidator()
        {
            RuleFor(c => c.Id).NotEqual(0).WithMessage("O Id não foi informado");
            RuleFor(c => c.Descricao).NotNull().WithMessage("O Campo não deve ser Nulo")
              .NotEmpty().WithMessage("O Campo não deve ser vazio")
              .MaximumLength(200).WithMessage("O Campo não deve ter mais de 200 caracteres")
              .MinimumLength(2).WithMessage("Provavelmente esse campo está faltando dígitos.");
        }
    }
}