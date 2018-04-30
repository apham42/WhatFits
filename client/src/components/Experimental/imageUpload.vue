<template>

 <div class="field-body">
<div class="file has-name">
  <label class="file-label">
    <input class="file-input" type="file" @change="onFileSelected" name="iamge">
    <span class="file-cta">
      <span class="file-icon">
        <i class="fas fa-upload"></i>
      </span>
      <span class="file-label">
        Choose an Image...
      </span>
    </span>
    <span class="file-name">
      {{profileImageName}}
    </span>
  </label>
</div>
  <button class="button"   @click="uploadImage">Upload</button>
  <img v-bind:src="this.imagePath">
  <br>
</div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'ImageUpload',
  components: {

  },
  data () {
    return {
      profileImageName: 'yourProfileImage.jpg',
      profileImage: '',
      isvalidImage: false,
      imagePath: 'http://localhost/images/profileImages/genericProfileImage.jpg',
      incomingPath: 'rsanchez92ProfileImage.jpg'
    }
  },
  methods: {
    onFileSelected (event) {
      console.log(event)
      // Validate Image
      var fileName = event.target.files[0].name
      var extension = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase()
      if (extension !== 'png' && extension !== 'jpg') {
        this.isvalidImage = false
        this.profileImageName = 'Invalid Image'
        return
      }
      if (fileName.length > 50) {
        this.isvalidImage = false
        this.profileimageName = 'Name too long'
        return
      }
      this.profileImage = event.target.files[0]
      this.profileImageName = event.target.files[0].name
    },
    uploadImage: function () {
      const fd = new FormData()
      fd.append('image', this.profileImage, this.profileImage.name)
      axios.post('http://localhost/server/v1/UserProfile/PostFormData',
        fd, // the data to post
        { headers: {
          'Content-type': 'application/x-www-form-urlencoded',
          'Access-Control-Allow-Origin': 'http://localhost:8081'
        }
        })
        .then(response => {
          console.log('Success')
          this.imagePath = this.$store.getters.getprofilepicture + this.incomingPath
        })
        .catch((error) => {
          console.log('Error')
          // Pushes the error messages into error to display
          if (error.response) {
            this.statusMessages = 'An error occured while Processing your request.'
            this.errorFlag = true
            console.log(error.response)
          } else if (error.request) {
            this.statusMessages = 'An error occured at the server.'
            this.errorFlag = true
            console.log(error.request)
          } else {
            this.statusMessages = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    }
  }
}
</script>

<style scoped>

</style>
