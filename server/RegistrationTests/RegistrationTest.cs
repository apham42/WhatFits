using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Whatfits.Hash;
using server.Model.Account;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using server.Model.Validators.Account_Validator;
using server.Constants;
using server.Model.Location;
using server.Model.Network_Communication;
using Newtonsoft.Json.Linq;
using System.Configuration;
using server.Model.Data_Transfer_Objects.Network_Communication_DTO_s;
using server.Model.Validators.Location_Validator;
using FluentValidation;
using server.Services;

namespace RegistrationTests
{
    public class RegistrationTest
    {
        [Fact]
        public void HashPassword()
        {
            HMAC256 hmac256 = new HMAC256();
            string password = "teamoutcast";
            string salt = hmac256.GenerateSalt();
            HashDTO dto = new HashDTO()
            {
                Original = password,
                Salt = salt
            };
            string hash = hmac256.Hash(dto);
            for ( int i = 0; i < 1000; i ++)
            {
                Assert.Equal(hash, hmac256.Hash(dto));
            }
        }

        [Fact]
        public void ValidateUserPassword()
        {
            UserCredential user = new UserCredential("TeamOutcast", "Spring");
            RegInfoValidator validator = new RegInfoValidator();
            RegInfoResponseDTO dto = new RegInfoResponseDTO();
            Assert.False(validator.ValidateUserCred(user,dto));

            Assert.False(dto.isSuccessful);
            Assert.Equal(dto.Messages.ElementAt(0), AccountConstants.PASSWORD_SHORT_ERROR);

            user = new UserCredential("TeamOutcast", "Spring2018");
            Assert.True(validator.ValidateUserCred(user, dto));

            user = new UserCredential("TeamOutcast", "Sprin¶g2018");
            Assert.False(validator.ValidateUserCred(user, dto));
            Assert.Equal(dto.Messages.ElementAt(0), AccountConstants.PASSWORD_INVALID_CHARACTERS_ERROR);
        }

        [Fact]
        public void ValidateUsername()
        {
            UserCredential user = new UserCredential("TestUser55", "Spring2018");
            RegInfoValidator validator = new RegInfoValidator();
            RegInfoResponseDTO dto = new RegInfoResponseDTO();
            Assert.False(validator.ValidateUserCred(user, dto));

            Assert.False(dto.isSuccessful);
            Assert.Equal("Username already exists. Please try again", dto.Messages.ElementAt(0));

            user = new UserCredential("TeamO¶tcast", "Spring2018");
            Assert.False(validator.ValidateUserCred(user, dto));
            Assert.Equal(dto.Messages.ElementAt(0), AccountConstants.USERNAME_INVALID_CHARACTERS_ERROR);
        }

        [Fact]
        public void DuplicateQuestions()
        {
            var securityQuestions = new List<SecurityQuestion>();
            RegInfoValidator validator = new RegInfoValidator();
            RegInfoResponseDTO dto = new RegInfoResponseDTO();

            // Testing for duplicate Security Question
            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite song?", "Pokemon Theme Song"));
            Assert.False(validator.ValidateQandAs(securityQuestions, dto));
            Assert.Equal(dto.Messages.ElementAt(0), AccountConstants.QUESTION_INVALID_ERROR);
        }

        [Fact]
        public void InvalidQuestion()
        {
            var securityQuestions = new List<SecurityQuestion>();
            RegInfoValidator validator = new RegInfoValidator();
            RegInfoResponseDTO dto = new RegInfoResponseDTO();

            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite dance team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite song?", "Pokemon Theme Song"));

            Assert.False(validator.ValidateQandAs(securityQuestions, dto));
            Assert.Equal(dto.Messages.ElementAt(0), AccountConstants.QUESTION_INVALID_ERROR);

            securityQuestions.Clear();
            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite dance team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion(null, "Pokemon Theme Song"));

            Assert.False(validator.ValidateQandAs(securityQuestions, dto));
            Assert.Equal(dto.Messages.ElementAt(0), AccountConstants.QUESTION_INVALID_ERROR);

        }

        [Fact]
        public void InvalidAnswer()
        {
            var securityQuestions = new List<SecurityQuestion>();
            RegInfoValidator validator = new RegInfoValidator();
            RegInfoResponseDTO dto = new RegInfoResponseDTO();

            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("In what city or town does your nearest sibling live?", "Baldwin Park"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite song?", ""));

            Assert.False(validator.ValidateQandAs(securityQuestions, dto));
            Assert.Equal(dto.Messages.ElementAt(0), AccountConstants.ANSWER_INVALID_ERROR);

            securityQuestions.Clear();
            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("In what city or town does your nearest sibling live?", "Baldwin Park"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite song?", null));

            Assert.False(validator.ValidateQandAs(securityQuestions, dto));
            Assert.Equal(dto.Messages.ElementAt(0), AccountConstants.ANSWER_INVALID_ERROR);
        }

        [Fact]
        public void ValidRegInfo()
        {
            var user = new UserCredential("TeamOutcast", "Spring2018");

            var securityQuestions = new List<SecurityQuestion>();
            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("In what city or town does your nearest sibling live?", "Baldwin Park"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite song?", "Pokemon"));

            var userLocation = new Address("1653 La Golondrina Ave", "Alhambra", "California", "91803");

            var regInfo = new RegInfo()
            {
                UserCredInfo = user,
                SecurityQandAs = securityQuestions,
                UserLocation = userLocation
            };

            RegInfoValidator validator = new RegInfoValidator();
            RegInfoResponseDTO dto = new RegInfoResponseDTO();
            dto = validator.Validate(regInfo);

            //JObject json = validator.result;
            //Assert.Equal(json["results"][0]["address_components"][3]["long_name"], "Los Angeles County");

            Assert.True(dto.isSuccessful);
        }

        [Fact]
        public void InvalidRegInfoPassword()
        {
            var user = new UserCredential("TeamOutcast", "a");

            var securityQuestions = new List<SecurityQuestion>();
            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("In what city or town does your nearest sibling live?", "Baldwin Park"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite song?", "Pokemon"));

            var userLocation = new Address("1653 La Golondrina Ave", "Alhambra", "California", "91803");

            var regInfo = new RegInfo()
            {
                UserCredInfo = user,
                SecurityQandAs = securityQuestions,
                UserLocation = userLocation
            };

            RegInfoValidator validator = new RegInfoValidator();
            RegInfoResponseDTO dto = new RegInfoResponseDTO();
            dto = validator.Validate(regInfo);
            Assert.False(dto.isSuccessful);
            Assert.Equal(AccountConstants.PASSWORD_SHORT_ERROR, dto.Messages.First());
        }

        [Fact]
        public void InvalidRegInfoQuestion()
        {
            var user = new UserCredential("TeamOutcast", "Spring2018");

            var securityQuestions = new List<SecurityQuestion>();
            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite song?", "Baldwin Park"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite song?", "Pokemon"));

            var userLocation = new Address("1653 La Golondrina Ave", "Alhambra", "California", "91803");

            var regInfo = new RegInfo()
            {
                UserCredInfo = user,
                SecurityQandAs = securityQuestions,
                UserLocation = userLocation
            };

            RegInfoValidator validator = new RegInfoValidator();
            RegInfoResponseDTO dto = new RegInfoResponseDTO();
            dto = validator.Validate(regInfo);
            Assert.False(dto.isSuccessful);
            Assert.Equal(AccountConstants.QUESTION_INVALID_ERROR, dto.Messages.First());
        }

        [Fact]
        public async void ValidGeoCodeRequest()
        {
            MapWebAPIComm network = new MapWebAPIComm();
            var requestDTO = new NetworkLocationDTO()
            {
                Location = "1600+Amphitheatre+Parkway,+Mountain+View,+CA"
            };
            var result = await network.Request(requestDTO);
            var json = JObject.Parse(result.Response);
            Assert.Equal(json["results"][0]["address_components"][4]["long_name"], "Santa Clara County");
            Assert.Equal(json["status"], "OK");
            JArray list = (JArray)json["results"][0]["address_components"];
            Assert.Equal(list.Count, 8);
            Assert.Equal(json["results"][0]["address_components"][4]["types"][0].ToString(), "administrative_area_level_2");
            Assert.Equal(json["results"][0]["geometry"]["location"]["lat"].ToString(), "37.4224082");
            Assert.Equal(json["results"][0]["geometry"]["location"]["lng"].ToString(), "-122.0856086");
        }

        [Fact]
        public void ValidDataConversion()
        {
            var address = new Address("1653 La Golondrina Ave", "Alhambra", "CA", "91803");
            var location = address.getLocation().Replace(' ', '+');
            Assert.Equal(location, "1653+La+Golondrina+Ave,+Alhambra,+CA");
            MapWebAPIComm network = new MapWebAPIComm();
            var mappedData = new WebAPIGeocode();
            var requestDTO = new NetworkLocationDTO()
            {
                Location = location
            };
            var test = Task.Run(async () => { return await network.Request(requestDTO); }).Result;
            string response = test.Response;
            var data = JObject.Parse(response);
            Assert.Equal(data["status"],("OK"));
            JArray convertedData = (JArray)data["results"][0]["address_components"];
            int addressComponentsLength = convertedData.Count;
            Assert.Equal(addressComponentsLength, 8);
            
            for (int i = 0; i < convertedData.Count; i++)
            {
                if (data["results"][0]["address_components"][i]["types"][0].ToString().Equals("administrative_area_level_2"))
                {
                    Assert.Equal( data["results"][0]["address_components"][i]["long_name"].ToString(), "Los Angeles County");

                }
            }
            Assert.Equal(data["results"][0]["geometry"]["location"]["lat"].ToString(), "34.0740499");
            Assert.Equal(data["results"][0]["geometry"]["location"]["lng"].ToString(), "-118.1531137");
        }

        [Fact]
        public void UserExists()
        {
            var user = new UserCredential("TeamOutcast", "Spring2018");

            var securityQuestions = new List<SecurityQuestion>();
            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("In what city or town does your nearest sibling live?", "Baldwin Park"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite song?", "Pokemon"));

            var userLocation = new Address("1653 La Golondrina Ave", "Alhambra", "California", "91803");

            var regInfo = new RegInfo()
            {
                UserCredInfo = user,
                SecurityQandAs = securityQuestions,
                UserLocation = userLocation
            };

            var service = new AccountService();
            Assert.False(service.CreateUser(regInfo).isSuccessful);
        }

        [Fact]
        public void CreateUser()
        {
            var user = new UserCredential("TeamOutcast491A", "Spring2018");

            var securityQuestions = new List<SecurityQuestion>();
            securityQuestions.Add(new SecurityQuestion("What is your favorite sports team?", "Patriots"));
            securityQuestions.Add(new SecurityQuestion("In what city or town does your nearest sibling live?", "Baldwin Park"));
            securityQuestions.Add(new SecurityQuestion("What is your favorite song?", "Pokemon"));

            var userLocation = new Address("1653 La Golondrina Ave", "Alhambra", "California", "91803");

            var regInfo = new RegInfo()
            {
                UserCredInfo = user,
                SecurityQandAs = securityQuestions,
                UserLocation = userLocation
            };

            var service = new AccountService();
            Assert.True(service.CreateUser(regInfo).isSuccessful);
        }

    }
}
