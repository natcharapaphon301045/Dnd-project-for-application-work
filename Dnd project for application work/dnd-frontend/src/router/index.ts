import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: HomeView,
        },
        {
            path: '/about',
            name: 'about',
            component: () => import('../views/AboutView.vue'),
        },
        {
            path: '/characters',
            name: 'characters',
            component: () => import('../views/CharacterView.vue'),
        },
        {
            path: '/races',
            name: 'races',
            component: () => import('../views/RaceView.vue'),
        },
        {
            path: '/classes',
            name: 'classes',
            component: () => import('../views/ClassView.vue'),
        },
    ],
})

export default router
