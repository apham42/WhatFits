using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using server.Model.Account;
using server.Constants;

namespace server.Model.Validators.Account_Validator
{
    public class SecurityQuestionValidator: AbstractValidator<List<SecurityQuestion>>
    {
        public SecurityQuestionValidator()
        {
           When(SecurityQuestions => SecurityQuestions != null, () =>
           {
               RuleFor(SecurityQuestions => SecurityQuestions.Count).Must(SecurityQuestionCount => SecurityQuestionCount == 3).WithMessage(AccountConstants.QUESTION_AMOUNT_ERROR);
               RuleFor(SecurityQuestions => SecurityQuestions).Must(checkAnswers).WithMessage(AccountConstants.ANSWER_INVALID_ERROR);
           });
        }


        public bool checkAnswers(List<SecurityQuestion> securityQuestions)
        {
            foreach(SecurityQuestion question in securityQuestions)
            {
                if (question.Answer == null || question.Answer.Equals("") || question.Answer.Length > 150)
                {
                    return false;
                }
            }
            return true;
        }
    }
}