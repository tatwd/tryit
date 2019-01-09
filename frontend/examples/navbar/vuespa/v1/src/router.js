import Vue from 'vue'
import VueRouter from 'vue-router'

import Home from './views/index.vue'
import Foo from './views/foo.vue'
import Bar from './views/bar.vue'
import Baz from './views/baz.vue'

Vue.use(VueRouter)

const routes = [
  { path: '/', component: Home },
  { path: '/foo', component: Foo },
  { path: '/bar', component: Bar },
  { path: '*', component: Baz }
]

const router = new VueRouter({
  mode: 'hash',
  routes
})

export default router
