import Vue from 'vue'
import App from './App.vue'
import router from './router'

// required bootstrap dependencies
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(BootstrapVue)

// required eCharts dependency
import "@/plugins/echarts";

Vue.config.productionTip = false


require("./assets/style.css");

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
