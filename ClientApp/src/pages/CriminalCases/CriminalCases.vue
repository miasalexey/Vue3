<template>
  <div>
    <criminal-case-form-for-create @create="addCriminalCase"/>
    <criminal-cases-list
      :criminal-cases="criminalCases"
    />
  </div>
</template>

<script>
import {useCriminalCases} from "@/pages/CriminalCases/compositionAPI/useCriminalCases";
import CriminalCasesList from "@/pages/CriminalCases/CriminalCasesList";
import CriminalCaseFormForCreate from "@/pages/CriminalCases/CriminalCaseFormForCreate";

export default {
  components: {CriminalCasesList,CriminalCaseFormForCreate},
  setup(props) {
    const {criminalCases,newCriminalCase,addCriminalCase} = useCriminalCases()


    return {
      criminalCases,newCriminalCase,addCriminalCase
    }
  }
}
</script>

<style scoped>

</style>