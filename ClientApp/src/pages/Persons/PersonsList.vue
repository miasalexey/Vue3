<template>
  <div>
    <persons-item
      v-for="person in persons"
      :person="person"
      :key="person.personId"
      />
  </div>
</template>

<script>
import PersonsItem from "@/pages/Persons/PersonsItem";
export default {
  components: {PersonsItem},
  props: {
    persons : {
      type: Array,
      required: true
    }
  }
}
</script>

<style scoped>

</style>


