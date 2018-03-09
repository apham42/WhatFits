<template>
  <div id="Chat">
    <div id="ChatBox">
      <div id="chathead">Friends</div>
      <div id="chatbody">
        <div id="username">ROBBY</div>
      </div>
    </div>
    <div id="MsgBox" style="right:300px">
      <div id="msghead">ROBBY</div>
      <div id="msgbody">
        <textarea id="receives" rows="10" name="lol"/>
      </div>
      <div id="msgfoot">
        <textarea id="messagesent" v-model="messages" rows="4" placeholder="Enter the message" required></textarea>
        <button id="send" type="submit" @click="SendMessage">Send Message</button><br/>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Chatt',
  data () {
    return {
      ws: new WebSocket('ws://localhost/server/chat'),
      messages: '',
      receives: ''
    }
  },
  mounted () {
    this.Connection()
  },
  methods: {
    Connection: function () {
      this.ws.onopen = function (event) {
        console.log('connected')
        this.onmessage = function receivemessage (event) {
          window.document.getElementById('receives').textContent = event.data
        }
      }
    },
    SendMessage: function () {
      if (this.ws.readyState === WebSocket.OPEN) {
        this.ws.send(this.messages)
      }
    }
  }
}
</script>
<style>
#ChatBox,#MsgBox{
  background: white;
  width: 250px;
  position: fixed;
  bottom: 0px;
  right: 20px;
  border-radius: 5px 5px 0px 0px;
  font-family: sans-serif;
}
#send{
  margin-right: 80%;
  background: gray
}
#chathead,#msghead{
  background: rgb(54, 53, 52);
  padding: 15px;
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
  padding: 10px 25px;
  position: relative;
  color: black;
}
#username:hover{
  background:#f8f8f8
}
#username:before{
  content:'';
  position:absolute;
  background:#2ecc71;
  width:10px;
  height:10px;
  left:5px;
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
