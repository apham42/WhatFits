using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using server.Model.Search;
using server.Constants;

namespace server.Business_Logic.Validators.Search_Validator
{
    public class SearchUserValidator : AbstractValidator<SearchUser>
    {
        public SearchUserValidator ()
        {
            RuleFor(x => x.RequestedBy).NotNull().WithMessage(SearchConstants.NO_REQUESTEDBY_ERROR);
            RuleFor(x => x.RequestedUser).NotNull().WithMessage(SearchConstants.NO_REQUESTED_USER_ERROR);
            When(x => x.RequestedBy != null && x.RequestedUser != null, () =>
            {
                RuleFor(x => x.RequestedBy).MinimumLength(2).WithMessage(SearchConstants.NO_REQUESTEDBY_ERROR);
                RuleFor(x => x.RequestedUser).MinimumLength(2).WithMessage(SearchConstants.NO_USER_ERROR);
            });
        }
    }
}