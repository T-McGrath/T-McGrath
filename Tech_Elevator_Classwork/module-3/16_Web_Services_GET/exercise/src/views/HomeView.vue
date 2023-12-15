<template>
  <div class="loading" v-if="isLoading">
    <p>Loading...</p>
  </div>
  <div v-else>
    <header class="flex">
      <h1>Topics</h1>
    </header>
    <topic-list v-bind:topics="topics"/>
  </div>
</template>

<script>
import topicService from "../services/TopicService.js";
import TopicList from '../components/TopicList.vue';

export default {
  components: {
    TopicList
  },
  data() {
    return {
      topics: [],
      isLoading: true
    };
  },
  methods: {
    getTopics() {
      topicService.list().then((response) => {
        if (response.status >= 400) {
          this.handleErrorResponse();
        }
        else {
          this.topics = response.data;
          this.isLoading = false;
        }
      })

    },
    handleErrorResponse() {
      this.isLoading = false;
      this.$store.commit('SET_NOTIFICATION', `Could not get topic data from server.`);
    }
  },
  created() {
    this.getTopics();
  }
}
</script>

<style scoped>
</style>