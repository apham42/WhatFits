// UserManagementValidation.js
// LIBRARY CLASS
var validations = {
  validateUserName: function (userName) {
    if (/^[A-Za-z2-64_]+$/.test(userName)) {
      return true
    }
    return true
  },
  validateFirstName: function (firstName) {
    if (/^[A-Za-z2-15_]+$/.test(firstName)) {
      return true
    }
    return false
  },
  validateLastName: function (lastName) {
    if (/^[A-Za-z2-15_]+$/.test(lastName)) {
      return true
    }
    return false
  },
  validateEmail: function (email) {
    if (/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(email)) {
      return true
    }
    return false
  },
  validateGender: function (gender) {
    if (/^[A-Za-z2-15_]+$/.test(gender)) {
      return true
    }
    return false
  },
  validateDescription: function (description) {
    if (/^[A-Za-z0-128_]+$/.test(description)) {
      return true
    }
    return false
  },
  validateProfileImage: function () {

  }
}
validations.validateUserName()
