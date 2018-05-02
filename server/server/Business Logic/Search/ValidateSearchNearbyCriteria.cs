using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;
using server.Model;
using server.Model.Search;
using FluentValidation.Results;
using server.Business_Logic.Validators.Search_Validator;
using server.Model.Data_Transfer_Objects.SearchDTO_s;
using server.Constants;

namespace server.Business_Logic.Search
{
    /// <summary>
    /// Validate Search Nearby Criteria by implementing the command pattern.
    /// </summary>
    public class ValidateSearchNearbyCriteria : ICommand
    {
        public SearchCriteria SearchNearbyCriteria { get; set; }

        public Outcome Execute()
        {
            var response = new Outcome();
            var result = new SearchResponseDTO();
            var messages = new List<string>();

            // returns error if criteria is null
            if (SearchNearbyCriteria == null)
            {
                result.IsSuccessful = false;
                messages.Add(SearchConstants.NO_CRITERIA_ERROR);
                result.Messages = messages;
                response.Result = result;
                return response;
            }
            var validator = new SearchNearbyCriteriaValidator();
            var results = validator.Validate(SearchNearbyCriteria);

            IList<ValidationFailure> failures = results.Errors;

            // Returns any error messages if there was any when validating
            if (failures.Any())
            {
                foreach (ValidationFailure failure in failures)
                {
                    messages.Add(failure.ErrorMessage);
                }
                result.IsSuccessful = false;
                result.Messages = messages;
                response.Result = result;
                return response;
            }

            // Sets the result as true to indicate it passed
            result.IsSuccessful = true;
            response.Result = result;
            return response;
        }
    }
}