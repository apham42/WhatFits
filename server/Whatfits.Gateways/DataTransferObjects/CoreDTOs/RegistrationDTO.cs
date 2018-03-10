using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models;

namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    public class RegistrationDTO
    {
        /*
        // UserData
        public int mID { get; set; }
        public string mEmail { get; set; }
        public string mFirstName { get; set; }
        public string mLastName { get; set; }
        public string mGender { get; set; }
        public Boolean mIsPartial { get; set; }
        public Boolean misDisable { get; set; }
        // Location
        public string mAddress { get; set; }
        public string mCity { get; set; }
        public string mState { get; set; }
        public string mZipcode { get; set; }

        // Credentials
        public string mUserName { get; set; }
        public string mPassword { get; set; }
        // Claims
        string mClaimType { get; set; }
        string mClaimValue { get; set; }
        List<int> mClaimID { get; set; }
        // PersonalKey
        public string mSalt { get; set; }
        // User data
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
        // Location
        public void SetAddress(string address)
        {
            mAddress = address;
        }
        public string GetAddress()
        {
            return mAddress;
        }
        public void SetCity(string city)
        {
            mCity = city;
        }
        public string GetCity()
        {
            return mCity;
        }
        public void SetState(string state)
        {
            mState = state;
        }
        public string GetState()
        {
            return mState;
        }
        public void SetZipcode(string zipcode)
        {
            mZipcode = zipcode;
        }
        public string GetZipcode()
        {
            return mZipcode;
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
        // UserClaims
        // Note Talk to Aaron about this
        public void SetUserClaims(List<int> ClaimID)
        {
            mClaimID = ClaimID;
        }
        public List<int> GetUserClaims()
        {
            return mClaimID;
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
        */
        // UserData
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Boolean IsPartial { get; set; }
        public Boolean IsDisable { get; set; }
        // Location
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        // Credentials
        public string UserName { get; set; }
        public string Password { get; set; }
        // Claims
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public List<int> ClaimID { get; set; }
        // PersonalKey
        public string Salt { get; set; }
    }
}
