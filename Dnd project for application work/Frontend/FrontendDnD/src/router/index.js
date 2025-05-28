import { createRouter, createWebHistory } from 'vue-router'

import MainView from '../views/MainView.vue'
import CharacterView from '../views/CharacterView.vue'
import RaceView from '../views/RaceView.vue'
import ClassView from '../views/ClassView.vue'

const routes = [
    { path: '/', name: 'MainView', component: MainView },
    { path: '/characters', name: 'Character', component: CharacterView },
    { path: '/races', name: 'Race', component: RaceView },
    { path: '/classes', name: 'Class', component: ClassView },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router
