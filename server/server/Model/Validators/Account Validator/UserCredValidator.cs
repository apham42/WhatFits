using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Constants;
using FluentValidation;
using server.Model.Account;
using System.Text.RegularExpressions;

namespace server.Model.Validators.Account_Validator
{
    public class UserCredValidator : AbstractValidator<UserCredential>
    {
        public UserCredValidator()
        {
            RuleFor(UserCredInfo => UserCredInfo.Username).NotNull();
            RuleFor(UserCredInfo => UserCredInfo.Password).NotNull();
            When(UserCredInfo => UserCredInfo.Password != null && UserCredInfo.Username != null, () =>
            {
                RuleFor(UserCredInfo => UserCredInfo.Username).Must(ValidateCharacters).WithMessage(AccountConstants.USERNAME_INVALID_CHARACTERS_ERROR);
                RuleFor(UserCredInfo => UserCredInfo.Username).MinimumLength(2).WithMessage(AccountConstants.USERNAME_SHORT_ERROR);
                RuleFor(UserCredInfo => UserCredInfo.Username).MaximumLength(64).WithMessage(AccountConstants.USERNAME_LONG_ERROR);

                RuleFor(UserCredInfo => UserCredInfo.Password).Must(ValidateCharacters).WithMessage(AccountConstants.PASSWORD_INVALID_CHARACTERS_ERROR);
                RuleFor(UserCredInfo => UserCredInfo.Password).MinimumLength(8).WithMessage(AccountConstants.PASSWORD_SHORT_ERROR);
                RuleFor(UserCredInfo => UserCredInfo.Password).MaximumLength(64).WithMessage(AccountConstants.PASSWORD_LONG_ERROR);
            });

        }

        public bool ValidateCharacters(string credential)
        {
            var rgxCheck = new Regex(AccountConstants.CREDCHARACTERS);
            try
            {
                if (rgxCheck.IsMatch(credential))
                {
                    return true;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                throw;
            }
            return false;
        }
    }
}