<template>
  <div class="loading" v-if="isLoading">
    <p>Loading...</p>
  </div>
  <div v-else>
    <nav>
      <router-link v-bind:to="{ name: 'TopicDetailsView', params: { topicId: topicId } }">Back to Topic Details</router-link>
    </nav>
    <message-details v-bind:message="message" />
  </div>
</template>

<script>
import messageService from "../services/MessageService.js";
import MessageDetails from '../components/MessageDetails.vue';

export default {
  components: {
    MessageDetails,
  },
  data(){
    return {
      topicId: this.$route.params.topicId,
      message: {},
      isLoading: true
    }
  },
  methods: {
    getMessage(id) {
      messageService.get(id).then(response => {
        this.message = response.data;
        this.isLoading = false;
      }).catch(error => {
        this.handleErrorResponse(error);
      });      
    },
    
    handleErrorResponse(error) {
      if (error.response.status == 404) {
          this.$router.push({name: 'NotFoundView'});
        } else {
          this.isLoading = false;
          this.$store.commit('SET_NOTIFICATION', `Could not get message data from server.`);
        }
    }
  },
  created() {
    this.getMessage(this.$route.params.messageId);
  }
};
</script>

<style scoped>
</style>
