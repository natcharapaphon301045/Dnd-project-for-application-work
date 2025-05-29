﻿import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import SvgIcon from '@jamescoyle/vue-icon'
import vuetify from './plugins/vuetify'
import '@mdi/font/css/materialdesignicons.css';
import './style.css'

const app = createApp(App)

app.use(router)
app.use(vuetify)
app.component('svg-icon', SvgIcon)

app.mount('#app')
