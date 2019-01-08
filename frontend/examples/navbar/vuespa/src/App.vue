<template>
  <div id="app">
    <navbar></navbar>
    <router-view></router-view>
    <footer>
      <a href="http://github.com/tatwd" target="_blank" rel="noopener noreferrer">
        <code>@tatwd</code>
      </a>
    </footer>
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue'

export default {
  name: 'app',
  components: {
    Navbar
  }
}
</script>

<style>
body {
  margin: 0;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

a {
  color: #42b983;
}
</style>
