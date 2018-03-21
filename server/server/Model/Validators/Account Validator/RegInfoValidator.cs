using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;
using server.Model.Data_Transfer_Objects.AccountDTO_s;

namespace server.Model.Validators.Account_Validator
{
    public class RegInfoValidator: IValidation<RegInfoResponseDTO>
    {
        public RegInfoResponseDTO Validate<RegInfo>(RegInfo dto)
        {
            var convert = dto;
            var skjfasdf = new RegInfoResponseDTO()
            {
                test = 4,
                Messages = new List<string>(),

            };

            return skjfasdf;
        }

        public int test ()
        {
            RegInfo test = new RegInfo();
            RegInfoResponseDTO dto = Validate(test);
            return dto.test;
        }
    }
}