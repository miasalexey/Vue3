<template>
  <div class="card" style="margin-top: 15px">
    <h5 class="card-header">Дело №:{{criminalCase.criminalCaseId}}</h5>
    <div class="card-body">
      <p class="card-text">Описание: {{criminalCase.title}}</p>
      <p class="card-text">Регион: {{criminalCase.region}}</p>
      <my-button>Подробнее</my-button>
      <my-button style="margin-left: 10px" >Удалить</my-button>
    </div>
  </div>
</template>

<script>
import MyButton from "@/components/UI/MyButton";
export default {
  components: {MyButton},
  props : {
    criminalCase: {
      type: Object,
      required: true
    }
  }
}
</script>

<style scoped>

</style>