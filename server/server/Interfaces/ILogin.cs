using server.Model.Account;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;

namespace server.Interfaces
{
    public interface ILogin
    {
        bool ValidateCredentials(LoginDTO loginDTO, ResponseDTO<LoginDTO> responseDTO);
        ResponseDTO<LoginDTO> GetUsersCredentails(LoginDTO loginDTO);
        LoginDTO UserCredentialTransformer(UserCredential userCredential);
        LoginResponseDTO GetLoginToken(ResponseDTO<LoginDTO> responseDTO);

    }
}