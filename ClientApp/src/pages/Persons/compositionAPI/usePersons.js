import {onMounted, ref} from 'vue';
import axios from 'axios'

export function usePersons() {
    const persons = ref([])
    const newPerson = {
        name: '',
        surName: '',
        address: '',
        countCriminalRecord: 0
    }
    const fetching  = async () => {
        try {
            const response = await axios.get('/api/personsController/all')
            persons.value = response.data
        } catch (e) {
            console.log(e)
        }
    }
    const addPerson = async(newPerson) => {
        try {
            const response = await axios.post('/api/personsController', newPerson)
            await fetching()
        } catch (e) {
            console.log(e)
        }
    }



    onMounted(fetching)
    return {
        persons,newPerson,addPerson
    }
}