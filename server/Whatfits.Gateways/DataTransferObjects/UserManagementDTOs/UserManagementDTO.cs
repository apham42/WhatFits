using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.DataTransferObjects.UserManagementDTOs
{
    public class UserManagementDTO
    {
        // User
        public int mID { get; set; }
        public string mEmail { get; set; }
        public string mFirstName { get; set; }
        public string mLastName { get; set; }
        public string mGender { get; set; }
        public Boolean mIsPartial { get; set; }
        public Boolean misDisable { get; set; }
        // Credentials
        public string mUserName { get; set; }
        public string mPassword { get; set; }
        // Claims
        public List<String> mClaims { get; set; }
        public String mClaimValue { get; set; }
        public string mClaimType { get; set; }
        // PersonalKey
        public string mSalt { get; set; }
        public void SetFirstName(string firstname)
        {
            mFirstName = firstname;
        }
        public String GetFirstName()
        {
            return mFirstName;
        }
        public void SetLastName(string lastname)
        {
            mLastName = lastname;
        }
        public String GetLastName()
        {
            return mLastName;
        }
        public void SetID(int id)
        {
            mID = id;
        }
        public int GetID()
        {
            return mID;
        }
        public void SetEmail(string email)
        {
            mEmail = email;
        }
        public string GetEmail()
        {
            return mEmail;
        }
        public void SetGender(string gender)
        {
            mGender = gender;
        }
        public string GetGender()
        {
            return mGender;
        }
        public void SetParialRegistration(Boolean isPartial)
        {
            mIsPartial = isPartial;
        }
        public Boolean GetPartialRegistration()
        {
            return mIsPartial;
        }
        public void SetIsDisabled(Boolean isDisable)
        {
            misDisable = isDisable;
        }
        public Boolean GetIsDisabled()
        {
            return misDisable;
        }
        // Credential
        public void SetUserName(string userName)
        {
            mUserName = userName;
        }
        public string GetUserName()
        {
            return mUserName;
        }
        public void SetPassword(string password)
        {
            mPassword = password;
        }
        public string GetPassword()
        {
            return mPassword;
        }
        // Claims
        public void SetClaims(List<String> newclaims, string claimvalue)
        {
            foreach (string item in newclaims)
            {
                mClaims.Add(item);
            }
            mClaimValue = claimvalue;
        }
        public List<String> GetClaims()
        {
            return mClaims;
        }
        public void SetClaimTypes(string claimType)
        {
            mClaimType = claimType;
        }
        public string GetClaimType()
        {
            return mClaimType;
        }
        public void SetClaimValue(string claimValue)
        {
            mClaimValue = claimValue;
        }
        public string GetClaimValue()
        {
            return mClaimValue;
        }
        // Personal Key
        public void SetSalt(string salt)
        {
            mSalt = salt;
        }
        public string GetSalt()
        {
            return mSalt;
        }
    }
}
