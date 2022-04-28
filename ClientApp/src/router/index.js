import { createRouter, createWebHistory } from 'vue-router'
import Main from "@/pages/Main";
import CriminalCases from "@/pages/CriminalCases/CriminalCases";
import Persons from "@/pages/Persons/Persons";

const routes = [
  {
    path: '/',
    component: Main
  },
  {
    path: '/criminalCases',
    component: CriminalCases
  },
  {
    path: '/persons',
    component: Persons
  },

]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
