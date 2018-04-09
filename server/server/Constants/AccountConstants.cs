using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Constants
{
    public class AccountConstants
    {
        public const string CREDCHARACTERS = @"^[ A-Za-z\d~`!@#$%^&*()-_+=\\|\]}\[{'"";:/?.>,<]+$";
        public const string USER_CREATED = "User has been created";
        public const string USER_CREATE_FAIL = "User could not be created. Please try again later.";
        public const string REGISTRATION_INVALID = "Registration Information is not valid.Please include the proper information needed.";

        // username constants
        public const string USERNAME_VALID = "Username is valid";
        public const string USERNAME_EXISTS_ERROR = "Username already exists";
        public const string USERNAME_INVALID_CHARACTERS_ERROR = "Username has invalid special characters";
        public const string USERNAME_SHORT_ERROR = "Username does not reach the minimum length of 8";
        public const string USERNAME_LONG_ERROR = "Username is too long. Maximum length is 64 characters";

        // password constants
        public const string PASSWORD_SHORT_ERROR = "Password does not reach the minimum length of 8";
        public const string PASSWORD_LONG_ERROR = "Password is too long. Maximum length is 64 characters";
        public const string PASSWORD_INVALID_CHARACTERS_ERROR = "Password has invalid special characters";

        // Address constants
        public const string ADDRESS_INVALID_ERROR = "Address does not exist";
        public const string ADDRESS_CONSTRAINT_ERROR = "Address does not exist in Los Angeles or Orange County";

        // Question and Answer constants
        public const string QUESTION_INVALID_ERROR = "Your security questions are not valid";
        public const string QUESTION_AMOUNT_ERROR = "Registration requires 3 security questions";
        public const string ANSWER_INVALID_ERROR = "Each question needs an answer";
    }
}