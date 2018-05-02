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
    public class ValidateSearchUserCriteria: ICommand
    {
        public SearchUser SearchUserCriteria { get; set; }

        public Outcome Execute()
        {
            var response = new Outcome();
            var result = new SearchResponseDTO();
            var messages = new List<string>();
            if (SearchUserCriteria == null)
            {
                result.IsSuccessful = false;
                messages.Add(SearchConstants.NO_CRITERIA_ERROR);
                result.Messages = messages;
                response.Result = result;
                return response;
            }
            var validator = new SearchUserValidator();
            var results = validator.Validate(SearchUserCriteria);

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

            result.IsSuccessful = true;
            response.Result = result;
            return response;
        }
    }
}