using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using server.Model.Account;
using System.Text.RegularExpressions;
using server.Constants;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using server.Model.Data_Transfer_Objects.AccountDTO_s;

namespace server.Model.Validators
{
    public class RegInfoValidator: AbstractValidator<RegInfoDTO>
    {
        private string usernameError = AccountConstants.USERNAME_EXISTS_ERROR;
        public RegInfoValidator()
        {
            RuleFor(regInfo => regInfo.UserCredInfo.Username).NotNull();
            RuleFor(regInfo => regInfo.UserCredInfo.Password).NotNull();
            When(regInfo => regInfo.UserCredInfo.Password != null && regInfo.UserCredInfo.Username != null, () =>
            {
                RuleFor(regInfo => regInfo.UserCredInfo.Username).Must(ValidateCharacters).WithMessage(AccountConstants.USERNAME_INVALID_CHARACTERS_ERROR);
                RuleFor(regInfo => regInfo.UserCredInfo.Username).MinimumLength(2).WithMessage(AccountConstants.USERNAME_SHORT_ERROR);
                RuleFor(regInfo => regInfo.UserCredInfo.Username).MaximumLength(64).WithMessage(AccountConstants.USERNAME_LONG_ERROR);
                RuleFor(regInfo => regInfo.UserCredInfo.Username).Must(CheckUsername).WithMessage(AccountConstants.USERNAME_EXISTS_ERROR);

                RuleFor(regInfo => regInfo.UserCredInfo.Password).Must(ValidateCharacters).WithMessage(AccountConstants.PASSWORD_INVALID_CHARACTERS_ERROR);
                RuleFor(regInfo => regInfo.UserCredInfo.Password).MinimumLength(8).WithMessage(AccountConstants.PASSWORD_SHORT_ERROR);
                RuleFor(regInfo => regInfo.UserCredInfo.Password).MaximumLength(64).WithMessage(AccountConstants.PASSWORD_LONG_ERROR);
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

        public bool CheckUsername (string username)
        {
            var status = false;
            var requestDTO = new UsernameDTO
            {
                Username = username
            };
            RegistrationGateway gateway = new RegistrationGateway();
            /**
            try
            {
                status = gateway.CheckUserName(requestDTO);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                usernameError = "Your request cannot be made right now. Please try again";
                throw;
            }
            finally
            {
                if (!status)
                {
                    usernameError = AccountConstants.USERNAME_EXISTS_ERROR;
                }
            }
            **/
            return gateway.CheckUserName(requestDTO);
        }

    }
}