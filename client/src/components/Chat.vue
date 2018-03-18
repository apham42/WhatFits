<template>
  <div id="Chat">
    <div id="ChatBox">
      <div id="chathead" v-on:click="chatshow = !chatshow">Friends</div>
      <div id="chatbody" v-if="chatshow">
        <div id="username" v-for ="(value, index) in chatusers" :key="index" list-style:none>
          <div id="user" v-on:click="SpanBox(index)">
            {{value}}
          </div>
        </div>
      </div>
    </div>
    <div id="MsgBox" style="right:290px" v-if="msgshow">
      <div id="msghead">
        {{clickeduser}}
      </div>
      <div id="msgbody">
        <textarea id="receives" rows="10"/>
      </div>
      <div id="msgfoot">
        <textarea id="messagesent" v-model="messages" v-on:keyup.enter="SendMessage" rows="4" placeholder="Enter the message"></textarea>
        <button id="send" type="submit" @click="SendMessage">Send Message</button><br/>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Chats',
  data () {
    return {
      ws: '',
      messages: '',
      onlineUser: '',
      clickeduser: '',
      chatusers: [],
      chatshow: false,
      msgshow: false
    }
  },
  mounted () {
    this.onlineUser = prompt('Enter your name')
    this.ws = new WebSocket('ws://localhost/server/chat' + '?username=' + this.onlineUser)
    this.Connection()
  },
  watch: {
    chatusers: function () {
      console.log('chatusers changed')
    }
  },
  methods: {
    Connection: function () {
      var vm = this
      this.ws.onopen = function (event) {
        console.log('connected')
        vm.ReceiveMessage()
      }
    },
    ReceiveMessage: function () {
      var vm = this
      this.ws.onmessage = function (event) {
        if (vm.chatusers.length > 0) {
          window.document.getElementById('receives').prepend(JSON.parse(event.data) + '\n')
        } else {
          vm.chatusers = JSON.parse(event.data).split(',')
          if (vm.chatusers.includes(vm.onlineUser)) {
            var index = vm.chatusers.indexOf(vm.onlineUser)
            vm.chatusers.splice(index, 1)
          }
        }
      }
    },
    SendMessage: function () {
      console.log('send message???')
      if (this.ws.readyState === WebSocket.OPEN) {
        this.ws.send(this.messages)
        this.messages = ''
      }
    },
    SpanBox: function (index) {
      this.clickeduser = this.chatusers[index]
      this.msgshow = !this.msgshow
    },
    Disconnection: function () {
      if (this.ws.readyState === WebSocket.OPEN) {
        this.ws.onclose()
      }
    },
    Error: function () {
      this.ws.onerror = function (event) {
        window.document.getElementById('receives').prepend(JSON.parse(event.data) + '\n')
      }
    }
  }
}
</script>
<style>
#ChatBox,#MsgBox{
  cursor: pointer;
  background: grey;
  width: 150px;
  position: fixed;
  bottom: 0px;
  right: 20px;
  border-radius: 5px 5px 0px 0px;
  font-family: sans-serif;
}
#send{
  margin-right: 80%;
  background: #16a085;
}
#chathead,#msghead{
  background: rgb(54, 53, 52);
  padding: 5px;
  color:white;
  border-radius: 5px 5px 0px 0px;
}
#chatbody{
  height: 400px;
}
#msghead{
  background:#3498db;
  padding:2px;
}
#msgbody{
  height:200px;
  overflow: auto;
  overflow-y: auto;
}
#msgclose{
  float:right;
  color:white;
  padding: 3px;
}
#msgfoot{
  width:250px;
  color:black;
}
#MsgBox{
  width: 250px;
  height: 350px;
  background: white;
  bottom: -5px;
}
#username{
  background: gray;
  padding: 5px 25px;
  position: relative;
  color: black;
}
#username:hover{
  background:white
}
#username:before{
  content:'';
  position:absolute;
  background:#2ecc71;
  width:10px;
  height:10px;
  left:35px;
  top: 12px;
}
#messagesent{
  border: transparent;
  width:96%;
  border-color: white;
  border-top: 1px solid #bdc3c7;
}
#receives{
  border-color: white;
  width:96%;
}
</style>
