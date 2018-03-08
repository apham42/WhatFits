<template>
    <div id="Chat">
        <p>{{message}}</p>
        <form id="message-form" action="#" method="get">
            <textarea v-model="messages" placeholder="Enter the message" required/><br/><br/>
            <button type="submit" @click="SendMessage">Send Message</button>
        </form>
        <br/>
        <div>
          {{receives}}
        </div>
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
    this.Connection(this.receives)
  },
  methods: {
    Connection: function (receives) {
      this.ws.onopen = function (event) {
        console.log('connected')
        this.onmessage = function receivemessage (event) {
          console.log(event.data)
          receives = event.data
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
