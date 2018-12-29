import Vue from 'vue'
import VueRouter from 'vue-router'

import Home from './views/index.vue'
import Foo from './views/foo.vue'
import Bar from './views/bar.vue'
import Others from './views/others.vue'

Vue.use(VueRouter)

const routes = [
  { path: '/', component: Home },
  { path: '/foo', component: Foo },
  { path: '/bar', component: Bar },
  { path: '*', component: Others }
]

const router = new VueRouter({
  routes
})

export default router
