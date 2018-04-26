using server.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.CoreDTOs;

namespace server.Model.Data_Transfer_Objects.AccountDTO_s
{
    public class IncommingAnswersDTO
    {
        public UserCredential userCredential { get; set; }
        public ResetPasswordResponseDTO resetPasswordResponseDTO { get; set; }
    }
}