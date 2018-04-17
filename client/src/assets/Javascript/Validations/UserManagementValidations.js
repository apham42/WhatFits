// UserManagementValidation.js
// LIBRARY CLASS
var namespaceplace = {
  validateUserName: function (userName) {
    if (userName.length < 2 || userName.length > 64) {
      return false
    } else {
      return true
    }
  }
}
namespaceplace.validateUserName()
