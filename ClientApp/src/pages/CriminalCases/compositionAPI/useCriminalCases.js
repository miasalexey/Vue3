import {computed, onMounted, ref} from 'vue';
import axios from 'axios'

export function useCriminalCases() {
    const criminalCases = ref([])
    const newCriminalCase = {
        dataRegistration: '',
        title: '',
        region: ''
    }
    const fetching  = async () => {
        try {
            const response = await axios.get('/api/criminalCases/all')
            criminalCases.value = response.data
        } catch (e){
            console.log(e)
        }
    }

    const addCriminalCase = async(newCriminalCase) => {
        try {
            const response = await axios.post('/api/criminalCases', newCriminalCase)
            await fetching()
        } catch (e) {
            console.log(e)
        }
    }

    onMounted(fetching)
    return {
        criminalCases,newCriminalCase,addCriminalCase
    }
}