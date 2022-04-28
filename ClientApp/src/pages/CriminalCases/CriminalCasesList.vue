<template>


  <div class="list-group">
    <criminal-cases-item
        v-for="criminalCase in criminalCases"
        :criminal-case="criminalCase"
        :key="criminalCase.criminalCaseId"
    />
  </div>

</template>

<script>



import CriminalCasesItem from "@/pages/CriminalCases/CriminalCasesItem";
export default {
  components: {CriminalCasesItem},
  props : {
    criminalCases: {
      type: Array,
      required: true
    }
  }
}
</script>

<style scoped>

</style>