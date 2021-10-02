using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GCAC.API.Extensions
{
    public class RequiredIf : ValidationAttribute
    {
        string _propriedade;

        public RequiredIf(string propriedade)
        {
            _propriedade = propriedade;
        }

        //protected override ValidationResult IsValid(object valor, ValidationContext validationContext)
        //{
        //    Cadastro cadastro = (Cadastro)validationContext.ObjectInstance;
        //    PropertyInfo propriedade = cadastro.GetType().GetProperty(_propriedade);

        //    if (cadastro.TipoId == (long)Cadastro.EnumTipo.Fisica)
        //    {
        //        if (propriedade.Name == "CPF" && String.IsNullOrEmpty(cadastro.CPF))
        //        {
        //            return new ValidationResult("O CPF é obrigatório.");
        //        }
        //        else if (propriedade.Name == "Nome" && String.IsNullOrEmpty(cadastro.Nome))
        //        {
        //            return new ValidationResult("O Nome é obrigatório.");
        //        }
        //    }
        //    else if (cadastro.TipoId == (long)Cadastro.EnumTipo.Juridica)
        //    {
        //        if (propriedade.Name == "CNPJ" && String.IsNullOrEmpty(cadastro.CNPJ))
        //        {
        //            return new ValidationResult("O CNPJ é obrigatório.");
        //        }
        //        else if (propriedade.Name == "RazaoSocial" && String.IsNullOrEmpty(cadastro.RazaoSocial))
        //        {
        //            return new ValidationResult("A Razão Social é obrigatória.");
        //        }
        //    }

        //    return ValidationResult.Success;
        //}
    }

    public class StringLengthIf : ValidationAttribute
    {
        string _propriedade;
        int _maximumLength;
        int _minimumLength;

        public StringLengthIf(string propriedade, int minimumLength, int maximumLength)
        {
            _propriedade = propriedade;
            _minimumLength = minimumLength;
            _maximumLength = maximumLength;
        }

        //protected override ValidationResult IsValid(object valor, ValidationContext validationContext)
        //{
        //    Cadastro cadastro = (Cadastro)validationContext.ObjectInstance;
        //    PropertyInfo propriedade = cadastro.GetType().GetProperty(_propriedade);

        //    if (cadastro.TipoId == (long)Cadastro.EnumTipo.Fisica)
        //    {
        //        if (propriedade.Name == "CPF" && !String.IsNullOrEmpty(cadastro.CPF) && (cadastro.CPF.Length != _minimumLength && cadastro.CPF.Length != _maximumLength))
        //        {
        //            return new ValidationResult("O CPF deve conter exatamente " + _maximumLength.ToString() + " caracteres.");
        //        }
        //        else if (propriedade.Name == "Nome" && !String.IsNullOrEmpty(cadastro.Nome) && (cadastro.Nome.Length < _minimumLength || cadastro.Nome.Length > _maximumLength))
        //        {
        //            return new ValidationResult("O Nome deve conter de " + _minimumLength.ToString() + " a " + _maximumLength.ToString() + " caracteres.");
        //        }
        //        if (propriedade.Name == "CAEPF" && !String.IsNullOrEmpty(cadastro.CAEPF) && (cadastro.CAEPF.Length != _minimumLength && cadastro.CAEPF.Length != _maximumLength))
        //        {
        //            return new ValidationResult("O CAEPF deve conter exatamente " + _maximumLength.ToString() + " caracteres.");
        //        }
        //        else if (propriedade.Name == "CNO" && !String.IsNullOrEmpty(cadastro.CNO) && (cadastro.CNO.Length != _minimumLength && cadastro.CNO.Length != _maximumLength))
        //        {
        //            return new ValidationResult("O CNO deve conter exatamente " + _maximumLength.ToString() + " caracteres.");
        //        }
        //    }
        //    else if (cadastro.TipoId == (long)Cadastro.EnumTipo.Juridica)
        //    {
        //        if (propriedade.Name == "CNPJ" && !String.IsNullOrEmpty(cadastro.CNPJ) && (cadastro.CNPJ.Length != _minimumLength && cadastro.CNPJ.Length != _maximumLength))
        //        {
        //            return new ValidationResult("O CNPJ deve conter exatamente " + _maximumLength.ToString() + " caracteres.");
        //        }
        //        else if (propriedade.Name == "RazaoSocial" && !String.IsNullOrEmpty(cadastro.RazaoSocial) && (cadastro.RazaoSocial.Length < _minimumLength || cadastro.RazaoSocial.Length > _maximumLength))
        //        {
        //            return new ValidationResult("A Razão Social deve conter de " + _minimumLength.ToString() + " a " + _maximumLength.ToString() + " caracteres.");
        //        }
        //        else if (propriedade.Name == "CNO" && !String.IsNullOrEmpty(cadastro.CNO) && (cadastro.CNO.Length != _minimumLength && cadastro.CNO.Length != _maximumLength))
        //        {
        //            return new ValidationResult("O CNO deve conter exatamente " + _maximumLength.ToString() + " caracteres.");
        //        }
        //    }

        //    if (propriedade.Name == "Complemento" && !String.IsNullOrEmpty(cadastro.Complemento) && (cadastro.Complemento.Length < _minimumLength || cadastro.Complemento.Length > _maximumLength))
        //    {
        //        return new ValidationResult("O Complemento deve conter de " + _minimumLength.ToString() + " a " + _maximumLength.ToString() + " caracteres.");
        //    }

        //    if (propriedade.Name == "Numero" && !String.IsNullOrEmpty(cadastro.Numero) && (cadastro.Numero.Length < _minimumLength || cadastro.Numero.Length > _maximumLength))
        //    {
        //        return new ValidationResult("O Número deve conter de " + _minimumLength.ToString() + " a " + _maximumLength.ToString() + " caracteres.");
        //    }

        //    return ValidationResult.Success;
        //}
    }
}