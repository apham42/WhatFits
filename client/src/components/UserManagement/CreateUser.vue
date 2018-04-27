<template>
<div>
   <h3 class="SectionTitle">Create User</h3>
    <form name="CreateUser" id="createUser" action="http://localhost/server/v1/management/CreateAdmin" method="POST">
      <div class="field">
        <label class="label">Username</label>
        <div class="control has-icons-left has-icons-right">
          <input class="input " v-model.trim="userName" @input="delayTouch($v.userName)" type="text" placeholder="UserName" value="">
          <span class="icon is-small is-left">
          <i class="fas fa-user"></i>
          </span>
          <!--
          <span class="icon is-small is-right">
          <i class="fas fa-check"></i>
          </span>
          -->
        </div>
        <div class="errorMessage">
                <span v-show="!$v.userName.required && $v.userName.$dirty">A UserName is required</span>
                <span v-show="!$v.userName.minLength && $v.userName.$dirty">Username must have at least {{$v.userName.$params.minLength.min}} letters</span>
                <span v-show="!$v.userName.maxLength && $v.username.$dirty">Username must have at most {{$v.userName.$params.maxLength.max}} letters</span>
                <span v-show="!validateCharacters(this.$data.userName) && $v.userName.$dirty && $v.userName.maxLength && $v.userName.minLength">Username has invalid characters</span>
        </div>
        <!-- <p class="help is-success">This userName is available</p>-->
      </div>
      <div class="field">
        <label class="label">Password</label>
        <div class="control has-icons-left has-icons-right">
          <input class="input" v-model.trim="password" @input="delayTouch($v.password)" type="password" placeholder="Password" value="">
          <span class="icon is-small is-left">
          <i class="fas fa-lock"></i>
          </span>
        </div>
        <div class="errorMessage">
          <span v-show="!$v.password.minLength && $v.password.$dirty">Minimum length is {{$v.password.$params.minLength.min}}</span>
          <span v-show="!$v.password.maxLength && $v.password.$dirty">Maximum length is {{$v.password.$params.maxLength.max}}</span>
          <span v-show="!$v.password.required && $v.password.$dirty">A password is required</span>
          <span v-show="!validateCharacters(this.$data.password) && $v.password.$dirty && $v.password.maxLength && $v.password.minLength">Password has invalid characters</span>
        </div>
        <!--<p class="help is-danger">This email is invalid</p>-->
      </div>
      <div class="field">
        <label class="label">Confirm Password</label>
        <div class="control has-icons-left has-icons-right">
          <input class="input" v-model.trim="confirmPassword" @input="delayTouch($v.confirmPassword)" type="password" placeholder="Password" value="">
          <span class="icon is-small is-left">
          <i class="fas fa-lock"></i>
          </span>
        </div>
        <div class="errorMessage">
          <span v-show="!$v.confirmPassword.sameAsPassword && $v.confirmPassword.$dirty">Passwords must be identical</span>
        </div>
        <!-- <p class="help is-danger">This email is invalid</p> -->
      </div>
      <div class="field">
        <label class="label">Address</label>
        <div class="control has-icons-left">
          <input class="input" v-model.trim="address" @input="delayTouch($v.address)" type="text" placeholder="Address">
          <span class="icon is-small is-left">
          <i class="fas fa-home"></i>
          </span>
        </div>
        <div class="errorMessage">
          <span v-show="!$v.address.maxLength && $v.address.$dirty">Maximum length is {{$v.address.$params.maxLength.max}}</span>
          <span v-show="!$v.address.required && $v.address.$dirty">Field is required</span>
        </div>
        <label class="label">City</label>
        <div class="control">
          <input class="input" v-model.trim="city" @input="delayTouch($v.city)" type="text" placeholder="City Name">
        </div>
        <div class="errorMessage">
          <span v-show="!$v.city.maxLength && $v.city.$dirty">Maximum length is {{$v.city.$params.maxLength.max}}</span>
          <span v-show="!$v.city.required && $v.city.$dirty">Field is required</span>
        </div>
        <label class="label">Zipcode</label>
        <div class="control">
          <input class="input" v-model.trim="zipCode" @input="delayTouch($v.zipCode)" type="text" placeholder="Zipcode">
        </div>
        <div class="errorMessage">
          <span v-show="!$v.zipCode.maxLength && $v.zipCode.$dirty">Maximum length is {{$v.zipCode.$params.maxLength.max}}</span>
          <span v-show="!$v.zipCode.minLength && $v.zipCode.$dirty">Minimum length is {{$v.zipCode.$params.minLength.min}}</span>
          <span v-show="!$v.zipCode.required && $v.zipCode.$dirty">Field is required</span>
        </div>
        <label class="label">State</label>
        <div class="control">
          <input class="input" v-model.trim="state" @input="delayTouch($v.state)" type="text" placeholder="State">
        </div>
        <div class="errorMessage">
          <span v-show="!$v.state.maxLength && $v.state.$dirty">Maximum length is {{$v.state.$params.maxLength.max}}</span>
          <span v-show="!$v.state.required && $v.state.$dirty">Field is required</span>
        </div>
      </div>
      <div class="field-body">
            <div class="field">
                <p class="control is-expanded">
                    <input class="input" type="text" placeholder="First Name" v-model.trim="userData.firstName" @input="delayTouch($v.userData.firstName)" v-bind:class="{error: $v.userData.firstName.$error, valid: $v.userData.firstName.$dirty && !$v.userData.firstName.$invalid}">
                </p>
                <div class="errorMessage">
                    <span v-show="!$v.userData.firstName.required && $v.userData.firstName.$dirty">First name is required</span>
                    <span v-show="!$v.userData.firstName.minLength && $v.userData.firstName.$dirty">First name must have at least {{$v.userData.firstName.$params.minLength.min}} letters</span>
                    <span v-show="!$v.userData.firstName.maxLength && $v.userData.firstName.$dirty">First name can't be this long {{$v.userData.firstName.$params.maxLength.max}} letters</span>
                </div>
            </div>
            <div class="field">
                <p class="control is-expanded">
                    <input class="input" type="text" placeholder="Last Name" v-model.trim="userData.lastName" @input="delayTouch($v.userData.lastName)" v-bind:class="{error: $v.userData.lastName.$error, valid: $v.userData.lastName.$dirty && !$v.userData.lastName.$invalid}">
                </p>
                <div class="errorMessage">
                    <span v-show="!$v.userData.lastName.required && $v.userData.lastName.$dirty">First name is required</span>
                    <span v-show="!$v.userData.lastName.minLength && $v.userData.lastName.$dirty">Last name must have at least {{$v.userData.lastName.$params.minLength.min}} letters</span>
                    <span v-show="!$v.userData.lastName.maxLength && $v.userData.lastName.$dirty">Last name can't be this long {{$v.userData.lastName.$params.maxLength.max}} letters</span>
                </div>
            </div>
        </div>
      <div class="field-body">
            <div class="field is-narrow">
                <div class="control">
                    <!--NOTE: Create lookup table of skill levels -->
                    <div class="select is-fullwidth">

                        <select v-model="userData.skillLevel">
                            <option value="Beginner">Beginner</option>
                            <option value="Intermediate">Intermediate</option>
                            <option value="Advance">Advance</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>

      <div class="field">
        <label class="label">Security Questions</label>
        <label class="label">Question #1</label>
        <div class="control">
          <div class="select is-fullwidth" >
            <select v-model="securityQues1">
              <option selected disabled>Select Question</option>
              <option v-for="securityQuestion1 in securityQuestionsSet1" :key="securityQuestion1"> {{securityQuestion1}} </option>
            </select>
          </div>
        </div>
        <br>
         <div class="control">
          <input class="input" v-model.trim="answerToSecQues1" @input="delayTouch($v.answerToSecQues1)" type="text" placeholder="Answer">
        </div>
        <div class="errorMessage">
          <span v-show="!$v.answerToSecQues1.maxLength && $v.answerToSecQues1.$dirty">Maximum length is {{$v.answerToSecQues1.$params.maxLength.max}}</span>
          <span v-show="!$v.answerToSecQues1.required && $v.answerToSecQues1.$dirty">Field is required</span>
          <span v-show="$v.answerToSecQues1.$dirty && securityQues1 == ''">Must select a question</span>
        </div>
      </div>
      <div class="field">
        <label class="label">Question #2</label>
        <div class="control">
          <div class="select is-fullwidth" >
            <select v-model="securityQues2">
              <option selected disabled>Select Question</option>
              <option v-for="securityQuestion2 in securityQuestionsSet2" :key="securityQuestion2"> {{securityQuestion2}} </option>
            </select>
          </div>
        </div>
        <br>
         <div class="control">
          <input class="input" v-model.trim="answerToSecQues2" @input="delayTouch($v.answerToSecQues2)" type="text" placeholder="Answer">
        </div>
        <div class="errorMessage">
          <span v-show="!$v.answerToSecQues2.maxLength && $v.answerToSecQues2.$dirty">Maximum length is {{$v.answerToSecQues2.$params.maxLength.max}}</span>
          <span v-show="!$v.answerToSecQues2.required && $v.answerToSecQues2.$dirty">Field is required</span>
          <span v-show="$v.answerToSecQues2.$dirty && securityQues2 == ''">Must select a question</span>
        </div>

      </div>
      <div class="field">
        <label class="label">Question #3</label>
        <div class="control">
          <div class="select is-fullwidth" >
            <select v-model="securityQues3">
              <option selected disabled>Select Question</option>
              <option v-for="securityQuestion3 in securityQuestionsSet3" :key="securityQuestion3"> {{securityQuestion3}} </option>
            </select>
          </div>
        </div>
        <br>
         <div class="control">
          <input class="input" v-model.trim="answerToSecQues3" @input="delayTouch($v.answerToSecQues3)" type="text" placeholder="Answer">
        </div>

        <div class="errorMessage">
          <span v-show="!$v.answerToSecQues3.maxLength && $v.answerToSecQues3.$dirty">Maximum length is {{$v.answerToSecQues3.$params.maxLength.max}}</span>
          <span v-show="!$v.answerToSecQues3.required && $v.answerToSecQues3.$dirty">Field is required</span>
          <span v-show="$v.answerToSecQues3.$dirty && securityQues3 == ''">Must select a question</span>
        </div>

      </div>
      <div class="field">
        <label class="label">User Type</label>
        <div class="control">
          <div class="select" >
            <select v-model="userType">
              <option  disabled selected >Select dropdown</option>
              <option>Administrator</option>
              <option >General</option>
            </select>
          </div>
        </div>
      </div>
      <!--
      <div class="field">
        <div class="control">
          <label class="checkbox">
          <input type="checkbox" v-model="terms">
          I agree to the <a href="#">terms and conditions</a>
          </label>
        </div>
      </div>
      -->
      <div class="field is-grouped">
        <div class="control">
          <button class="button is-primary" :disabled="$v.$invalid || !validateCharacters(this.$data.userName) || !validateCharacters(this.$data.password)" @click.prevent="createNewUser">Create {{userType}}</button>
        </div>
        <div class="control">
          <button class="button is-secondary" @click.prevent="clearForm">Clear</button>
        </div>
      </div>

      <div v-if="this.errorFlags.createUserFlag == true" class="errorMessage">
            <span class = "help">{{this.statusMessages.createUserResponse}}</span>
        </div>
        <div v-if="this.errorFlags.createUserFlag == false" class="successMessage">
            <span>{{this.statusMessages.createUserResponse}}</span>
        </div>
    </form>
</div>
</template>
<script>
export default {
  name: 'CreateUser',
  data () {
    return {

    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
