<template>
<div id="Chat">
   <div id="ChatBox">
      <div id="chathead" v-on:click="SpanList()">Follows</div>
      <div id="chatbody" v-if="chatshow">
         <div id="username" v-for="(value, index) in chatusers" :key="index" list-style:none>
            <div id="user" v-on:click="SpanBox(index)">
               {{value.UserName}}
            </div>
         </div>
      </div>
   </div>
   <div id="MsgBox" style="right:290px" v-if="msgshow">
      <div id="msghead">
         {{clickeduser}}
      </div>
      <div id="msgbody">
         <textarea id="receives" rows="10" />
      </div>
      <div id="msgfoot">
      <textarea id="messagesent" v-model="messages" v-on:keyup.enter="SendMessage" rows="4" placeholder="Enter the message"></textarea>
      <button id="send" type="submit" @click="SendMessage">Send Message</button><br/>
      </div>
   </div>
</div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'Chats',
  data () {
    return {
      ws: '',
      messages: '',
      onlineUser: '',
      clickeduser: '',
      clickedid: 0,
      chatusers: [],
      chatshow: false,
      msgshow: false,
      ciphertext: null,
      key: [],
      iv: [],
      receivestring: '',
      messageArray: []
    }
  },
  created () {
    // whenever the browser about to close, close webocket connection as well
    document.addEventListener('beforeunload', this.Disconnection)
  },
  mounted () {
    // ask for username when chat webapi gets called and request websocket connection to server
    // this.onlineUser = prompt('Enter your name')
    this.onlineUser = this.$store.getters.getusername
    this.ws = new WebSocket('ws://localhost/server/v1/chat/connect' + '?username=' + this.onlineUser)
    this.Connection()
  },
  watch: {
    // detects online users changes
    chatusers: function () {
      console.log('chatusers changed')
    }
  },
  methods: {
    Connection: function () {
      var vm = this
      // get secret key and initial value from server
      vm.GetIV()
      this.ws.onopen = function (event) {
        console.log('connected')
        vm.ReceiveMessage()
      }
    },
    ReceiveMessage: function () {
      var vm = this
      this.ws.onmessage = function (event) {
        console.log('receive')
        try {
          vm.Decryption(event.data)
          // if decryption successed
          // show decypted messaged on the receiver side
          window.document.getElementById('receives').prepend(vm.receivestring + '\n')
        } catch (error) { // server message cannot decrypted, since it is not encypted
          // send message to offline user
          if (event.data === ' ') {
            window.document.getElementById('receives').prepend('\n' + 'User is offline' + '\n')
          }
        }
      }
    },
    SendMessage: function () {
      // check if user is still connected  before send
      if (this.ws.readyState === WebSocket.OPEN) {
        this.Encryption()
        var jmsg = {
          UserName: this.clickeduser,
          MessageContent: this.ciphertext
        }
        this.ws.send(JSON.stringify(jmsg))
        window.document.getElementById('receives').prepend('You said: ' + this.messages)
        console.log('sent')
        // clear the message input area
        this.messages = ''
      }
    },
    // set visability of the messagebox
    SpanBox: function (index) {
      this.clickeduser = this.chatusers[index].UserName
      this.clickedid = this.chatusers[index].PersonFollowing
      this.msgshow = !this.msgshow
    },
    SpanList: function () {
      var vm = this
      if (vm.chatshow === false) {
        vm.GetFollows()
        vm.chatshow = !vm.chatshow
      } else {
        vm.chatshow = !vm.chatshow
      }
    },
    Disconnection: function (event) {
      if (this.ws.readyState === WebSocket.OPEN) {
        console.log(event)
        this.ws.onclose()
      }
    },
    Error: function () {
      console.log('error')
      this.ws.onerror = function (event) {
        window.document.getElementById('receives').prepend(JSON.parse(event.data) + '\n')
      }
    },
    // AES 128 CBC Encryption
    Encryption: function () {
      // get initial value from server
      console.log('encryption called')
      var AesJS = require('aes-js')
      // padding message to 16 bytes
      var StringtoBytes = AesJS.utils.utf8.toBytes(this.Padding(this.messages))
      // eslint-disable-next-line
      var AesCBC = new AesJS.ModeOfOperation.cbc(this.key, this.iv)
      var EncryptedBytes = AesCBC.encrypt(StringtoBytes)
      // convert to hex for eaiser transfer
      var EncryptedHex = AesJS.utils.hex.fromBytes(EncryptedBytes)
      this.ciphertext = EncryptedHex
      console.log(this.ciphertext)
    },
    // AES 128 CBC Decryption
    Decryption: function (data) {
      var AesJS = require('aes-js')
      console.log('decryption called')
      console.log(data)
      var res = data.split(' ')
      var hexmessage = res[2]
      console.log(hexmessage)
      var EncryptedBytes = AesJS.utils.hex.toBytes(hexmessage)
      // eslint-disable-next-line
      var AesCBC = new AesJS.ModeOfOperation.cbc(this.key, this.iv)
      var DecryptedBytes = AesCBC.decrypt(EncryptedBytes)
      var Decryptedtext = AesJS.utils.utf8.fromBytes(DecryptedBytes)
      res[2] = Decryptedtext
      // save message in client side when message box closed
      this.messageArray.push([res[0], res[2]])
      console.log(this.messageArray)
      // prepare message to be show in the message box
      this.receivestring = res.join(' ')
      console.log(this.receivestring)
    },
    // padding user's sending message to 16 bytes base
    Padding: function (source) {
      var paddchar = ' '
      console.log(source.length)
      var extra = source.length % 16
      console.log(extra)
      if (extra > 0) {
        for (var i = 0; i < 16 - extra; i++) {
          source += paddchar
        }
      }
      console.log(source.length)
      return source
    },
    // get follows list from server
    GetFollows: function () {
      var vm = this
      console.log('call follows')
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/follows/getfollows',
        data: {
          'Username': this.$store.getters.getusername
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then(response => {
          console.log(response.data)
          vm.chatusers = response.data
        }).catch((error) => {
          // Pushes the error messages into error to display
          if (error.response) {
            this.errorMessage = 'Error: An Error Occurd.'
            this.errorFlag = true
            console.log(error.response)
          } else if (error.request) {
            this.errorMessage = 'Error: Server Error'
            this.errorFlag = true
            console.log(error.request)
          } else {
            this.errorMessage = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    },
    // get initial value from server for encryption and decryption
    GetIV: function () {
      var vm = this
      console.log('get IV')
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/follows/getinitialvalue',
        data: {
          'Username': this.$store.getters.getusername
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then(response => {
          console.log(response.data)
          vm.iv = response.data
          vm.key = response.data
        }).catch((error) => {
          // Pushes the error messages into error to display
          if (error.response) {
            this.errorMessage = 'Error: An Error Occurd.'
            this.errorFlag = true
            console.log(error.response)
          } else if (error.request) {
            this.errorMessage = 'Error: Server Error'
            this.errorFlag = true
            console.log(error.request)
          } else {
            this.errorMessage = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    }
  }
}
</script>
<style>
#ChatBox,#MsgBox{
  cursor: pointer;
  background: #abeceb;
  width: 150px;
  position: fixed;
  bottom: 0px;
  right: 20px;
  border-radius: 5px 5px 0px 0px;
  font-family: sans-serif;
  transition: 0.5s;
}
#send{
  margin-right: 80%;
  width: 100px;
  height: 35px;
  background: #34495e;
  color:white;
  border: 1px solid #34495e;
}
#chathead,#msghead{
  background: #34495e;
  padding: 5px;
  color:white;
  border-radius: 5px 5px 0px 0px;
  text-align: center;
  text-shadow: 0 5px 5px rgba(0,0,0,.2);
}
#chathead:hover{
  background:white;
  border:solid #34495e;
  text-shadow: 0 5px 5px rgba(0,0,0,.2);
  color:grey;
}
#chatbody{
  height: 330px;
  overflow-y: auto;
}
#msghead{
  background:#34495e;
  padding:2px;
}
#msgbody{
  height:160px;
}
#msgclose{
  float:right;
  color:white;
  padding: 3px;
}
#msgfoot{
  width:200px;
  color:black;
}
#MsgBox{
  width: 250px;
  height: 300px;
  background: white;
  border: 2px solid #34495e;
  padding: 2px;
  bottom: -5px;
}
#username{
  font-family: sans-serif;
  padding: 5px 25px;
  position: relative;
  color: black;
}
#username:hover{
  background:white;
  border:solid #34495e;
  text-shadow: 0 5px 5px rgba(0,0,0,.2);
  color:grey;
}
#username:before{
  border-radius: 50%;
  content:'';
  position:absolute;
  background:#2ecc71;
  width:10px;
  height:10px;
  left:10px;
  top: 12px;
}
#messagesent{
  width:100%;
  border-color: white;
  border-top: 2px solid #bdc3c7;
  border-bottom: 2px solid #bdc3c7;

}
#receives{
  border-color: white;
  width:96%;
}
</style>
