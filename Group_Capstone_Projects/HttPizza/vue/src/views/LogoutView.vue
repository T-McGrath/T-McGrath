<template>
  <div style="margin-left:15%">
    <div id="login" >
  <h1>Logout</h1>
</div>
  </div>
</template>

<script>
export default {
  created() {
    this.$store.commit("LOGOUT");
    this.$router.push("/");
  }
};
</script>
<style>
.login {
  text-align: center;
  margin-top: 30px; 
  font-size: 18px;
}

</style>