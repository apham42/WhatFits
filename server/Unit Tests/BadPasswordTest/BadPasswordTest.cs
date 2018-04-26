using server.Business_Logic.Services;
using System;
using System.Collections.Generic;
using Xunit;
namespace Unit_Tests.BadPasswordTest
{
    public class BadPasswordTest
    {
        BadPasswordService service = new BadPasswordService();
        [Fact]
        public void CheckStrongPasswords()
        {
            // Arrange
            List<string> strongPasswords = new List<string>();
            strongPasswords.Add("1Ki77y");
            strongPasswords.Add("BankLogin!3");
            strongPasswords.Add("SterlingGmail20.15");
            strongPasswords.Add("!Lov3MyPiano");
            strongPasswords.Add("d3ltagamm@");
            strongPasswords.Add("&ebay.44");
            strongPasswords.Add("!q?G-M6vKl;gKZS");
            strongPasswords.Add("CM3Y)j5n_AN(Rjz");
            strongPasswords.Add("aldkfjasvioae;");
            strongPasswords.Add("oI77087046A4");
            strongPasswords.Add("19Nw423129Z8");
            strongPasswords.Add("22kY825103B9");
            strongPasswords.Add("Kq44734i3561");
            strongPasswords.Add("Cf74469384r5");
            strongPasswords.Add("3n3P808450r1");
            strongPasswords.Add("3U52r3942978");
            strongPasswords.Add("k666B855023C");
            strongPasswords.Add("63iY2063171y");
            strongPasswords.Add("Xq40092672f2");
            // Act
            foreach (var password in strongPasswords)
            {
                Assert.False(service.BadPassword(password));
            }
        }
        [Fact]
        void CheckWeakPasswords()
        {
            /*
            List<string> weakPasswords = new List<string>();
            weakPasswords.Add("123456");
            weakPasswords.Add("porsche");
            weakPasswords.Add("firebird");
            weakPasswords.Add("rosebud");
            weakPasswords.Add("princeguitar");
            weakPasswords.Add("guitar");
            weakPasswords.Add("fishing");
            weakPasswords.Add("bigdick");
            weakPasswords.Add("chester");
            weakPasswords.Add("snoopy");
            weakPasswords.Add("iloveyou");
            weakPasswords.Add("131313");
            weakPasswords.Add("pussies");
            weakPasswords.Add("samantha");
            weakPasswords.Add("mistress");
            weakPasswords.Add("miller");
            weakPasswords.Add("hello");
            weakPasswords.Add("albert");
            weakPasswords.Add("success");
            weakPasswords.Add("oliver");
            weakPasswords.Add("please");
            // Act
            foreach (var password in weakPasswords)
            {
                Assert.True(service.BadPassword(password));
            }
            */
            string pass = "password123";
            Assert.True(service.BadPassword(pass));
        }
    }
}
