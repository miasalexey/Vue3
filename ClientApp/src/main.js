import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import components from '@/components/UI'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"

const app = createApp(App)

components.forEach(component => {
    app.component(component.name, component)
})



app

    .use(router)
    .mount('#app')
