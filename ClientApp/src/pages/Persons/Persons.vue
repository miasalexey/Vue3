<template>
  <div>
    <person-form-for-create @create="addPerson" />
    <persons-list :persons="persons"/>
  </div>
</template>

<script>
import {usePersons} from "@/pages/Persons/compositionAPI/usePersons";
import PersonsList from "@/pages/Persons/PersonsList";
import PersonFormForCreate from "@/pages/Persons/PersonFormForCreate"

export default {
  components: {PersonsList,PersonFormForCreate},
  setup(props) {

    const {persons,newPerson,addPerson} = usePersons()


    return {
      persons,newPerson,addPerson
   }
  }
}
</script>

<style scoped>

</style>