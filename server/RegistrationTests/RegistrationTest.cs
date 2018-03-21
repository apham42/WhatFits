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
        public void test()
        {
            RegInfo reg = new RegInfo ();
            RegInfoValidator tests = new RegInfoValidator();
            bool passed = false;
            if ( tests.test() == 4)
            {
                passed = true;
            }
            Assert.True(passed);
        }

    }
}
