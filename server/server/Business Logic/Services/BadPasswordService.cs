using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using server.Constants;
using Whatfits.Hash;
using System.IO;
using System.Net.Http;

namespace server.Business_Logic.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class BadPasswordService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool BadPassword(string password)
        {
            // Need this to communicate with the service, without it fails
           ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // Hashing Password from Security Layer hashing methods
            SHA1CNG hashingService = new SHA1CNG();
            string hashedPassword = hashingService.Hash(password);
            // Checking if the hashed password length is greater than 5 so we
            // don't run into errors when getting the prefix and suffix.
            if(hashedPassword.Length < 6)
            {
                // This hashed password length is too short to separate.
                // Returning false
                return false;
            }
            // Separating both prefix and suffix from the hashed password
            string prefix = hashedPassword.Substring(0, 5);
            string suffix = hashedPassword.Remove(0, 5);
            // Sending request to service with the prefix appended to url
            string response = SendRequest(prefix);
            // Processing Results found in the service
            return ProcessResponse(response,suffix);

        }
        /// <summary>
        /// Makes a GET request to a webservice to determine password strength.
        /// </summary>
        /// <param name="prefix"> 5 character string</param>
        /// <returns>A long response with</returns>
        private string SendRequest(string prefix)
        {
            // Declaring empty variable to take in response from the service
            string payload = "";
            // Appending prefix to url for pwnedpassword
            string url = @"https://api.pwnedpasswords.com/range/" + prefix;
            // Preparing request 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            // Getting resposne and reading it to a string.
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                payload = reader.ReadToEnd();
            }
            // Returing response from server as a string
            return payload;
        }
        /// <summary>
        /// Processing Response from the pwnd webservice
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="originalpassword"></param>
        /// <param name="prefix"></param>
        /// <returns>Returns true if the password is bad, returns false if the password is safe or not found.</returns>
        private bool ProcessResponse(string payload, string passwordSuffix)
        {
            // Declaring a delimiter array to filer the payload into a list of 
            char[] delimiterChars = { '\n','\r' };
            payload = payload.Replace('\r', ' ');
            var suffixList = payload.Split(delimiterChars);
            foreach (var line in suffixList)
            {
                var currentRow = line.Split(':');
                // Comparing the suffix of the password with the suffixes in the list
                if (passwordSuffix == currentRow[0])
                {
                    int value = Int32.Parse(currentRow[1]);
                    if (value < BadPasswordConstants.MINIMUMRANGE )
                    {
                        // Returing false, it's range is within acceptable parameters for being a valid
                        return false;
                    }
                    // The password fell outside the acceptable range of a good password ie: BAD PASSWORD
                    return true;
                }
            }
            // The entire list has been iterated and found zero comparisons there for valid password.
            return false;
        }

    }
}