<template>
  <div class="navbar">
    <router-link
      v-for="(link, i) in navlinks"
      :key="i"
      :to="link.url"
      :class="`navlink ${ isActive(link.url) && 'active' }`"
    >{{ link.text }}</router-link>
  </div>
</template>

<script>
export default {
  data() {
    return {
      navlinks: [
        { text: 'Home', url: '/' },
        { text: 'Foo', url: '/foo' },
        { text: 'Bar', url: '/bar' },
      ]
    }
  },
  methods: {
    isActive(url) {
      return this.$route.path === url || ''
    }
  }
}
</script>

<style scoped>
.navbar {
  background-color: #f6f6f6;
}
.navlink {
  padding: 15px;
  display: inline-block;
}
.navlink.active {
  color: red;
}
</style>

