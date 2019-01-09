import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/index.vue'

Vue.use(Router)

export default new Router({
  mode: 'hash',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/foo',
      name: 'foo',
      component: () => import(/* webpackChunkName: "about" */ './views/foo.vue')
    },
    {
      path: '/bar',
      name: 'bar',
      component: () => import(/* webpackChunkName: "about" */ './views/bar.vue')
    },
    {
      path: '*',
      name: 'baz',
      component: () => import(/* webpackChunkName: "about" */ './views/baz.vue')
    }
  ]
})
