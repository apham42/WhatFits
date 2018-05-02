using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using server.Model.Search;
using server.Constants;


namespace server.Business_Logic.Validators.Search_Validator
{
    /// <summary>
    /// Validate the Search Nearby Criteria using Fluent Validation
    /// </summary>
    public class SearchNearbyCriteriaValidator : AbstractValidator<SearchCriteria>
    {
        public SearchNearbyCriteriaValidator()
        {
            RuleFor(x => x.RequestedUser).NotNull().WithMessage(SearchConstants.NO_REQUESTEDBY_ERROR);
            RuleFor(x => x.RequestedSearch).NotNull().WithMessage(SearchConstants.NO_REQUESTED_SEARCH_ERROR);
            RuleFor(x => x.Skill).NotNull().WithMessage(SearchConstants.NO_SKILL_ERROR);
            RuleFor(x => x.Distance).NotNull().WithMessage(SearchConstants.NO_DISTANCE_ERROR);
            When(x => x.RequestedUser != null && x.RequestedSearch != null && x.Skill != null && x.Distance != null, () =>
            {
                RuleFor(x => x.RequestedUser).MinimumLength(2).WithMessage(SearchConstants.NO_REQUESTEDBY_ERROR);
                RuleFor(x => x.RequestedSearch).MinimumLength(2).WithMessage(SearchConstants.NO_REQUESTED_SEARCH_ERROR);
                RuleFor(x => x.Distance.Value).GreaterThanOrEqualTo(0).WithMessage(SearchConstants.NO_DISTANCE_ERROR);
            });
        }
    }
}