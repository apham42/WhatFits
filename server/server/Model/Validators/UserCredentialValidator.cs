using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using server.Model.Account;
using System.Text.RegularExpressions;
using server.Constants;

namespace server.Model.Validators
{
    public class UserCredentialValidator: AbstractValidator<UserCredentials>
    {
        public UserCredentialValidator()
        {
            RuleFor(userCred => userCred.UserName).Must(ValidateCharacters).WithMessage(AccountConstants.USERNAME_INVALID_CHARACTERS_ERROR);
            RuleFor(userCred => userCred.UserName).MinimumLength(8).WithMessage(AccountConstants.USERNAME_SHORT_ERROR);
            RuleFor(userCred => userCred.UserName).MaximumLength(64).WithMessage(AccountConstants.USERNAME_LONG_ERROR);
            RuleFor(userCred => userCred.UserName).Must(CheckUsername).WithMessage(AccountConstants.USERNAME_EXISTS_ERROR);

            RuleFor(userCred => userCred.Password).Must(ValidateCharacters).WithMessage(AccountConstants.PASSWORD_INVALID_CHARACTERS_ERROR);
            RuleFor(userCred => userCred.Password).MinimumLength(8).WithMessage(AccountConstants.PASSWORD_SHORT_ERROR);
            RuleFor(userCred => userCred.Password).MaximumLength(64).WithMessage(AccountConstants.PASSWORD_LONG_ERROR);
        }

        public bool ValidateCharacters(string credential)
        {
            var rgxCheck = new Regex(AccountConstants.CREDCHARACTERS);
            if (rgxCheck.IsMatch(credential))
            {
                return true;
            }
            return false;
        }

        public bool CheckUsername (string username)
        {
            return true;
        }
    }
}