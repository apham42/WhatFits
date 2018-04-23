using server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;
using Whatfits.Hash;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.DTOs;

namespace server.Business_Logic.Login
{
    public class ValidateCredentials : ICommand
    {
        public LoginDTO loginDTO { get; set; }
        public ResponseDTO<LoginDTO> responseDTO { get; set; }

        /// <summary>
        /// Execute ValidateCredentials
        /// check if hash password is equal to hash pass on db
        /// </summary>
        /// <returns>returns true if correct pass else false</returns>
        public Outcome Execute()
        {
            var response = new Outcome();

            var hashDTO = new HashDTO()
            {
                Original = loginDTO.Password + responseDTO.Data.Salt
            };

            var hashedincommingpassword = new HMAC256().Hash(hashDTO);

            if(hashedincommingpassword == responseDTO.Data.Password)
            {
                response.Result = true;
                return response;
            }

            response.Result = false;
            return response;
        }
    }
}