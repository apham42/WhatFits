<template>
    <div id="Chat">
        <p>{{message}}</p>
        <form id="message-form" action="#" method="get">
            <textarea v-model="messages" placeholder="Enter the message" required/><br/><br/>
            <button type="submit" @click="SendMessage">Send Message</button>
        </form>
        <br/>
        <textarea id="receives" name="lol"/>
    </div>
</template>

<script>
export default {
  name: 'Chatt',
  data () {
    return {
      ws: new WebSocket('ws://localhost/server/chat'),
      message: 'Welcome',
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
