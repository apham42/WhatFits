<template>
    <div class="chatlist">
        <ul>
            <li v-for="item in sessions" :key="{ active: item.id === currentId }" @click="selectSession(item.id)">
                <p class="name">{{item.user.name}}</p>
            </li>
        </ul>
    </div>
</template>

<script>
import {actions} from './store'

export default {
  vuex: {
    actions: actions,
    getters: {
      currentId: ({ currentSessionId }) => currentSessionId
    }
  }
}
</script>
