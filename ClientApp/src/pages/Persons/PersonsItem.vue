<template>
  <div class="card" style="margin-top: 15px">
    <h5 class="card-header">{{person.surName}} {{person.name}}</h5>
    <div class="card-body">
      <p class="card-text">Адрес: {{person.address}}</p>
      <p class="card-text">Кол-во судимостей {{person.countCriminalRecord}}</p>
      <p class="card-text">Кол-во судимостей {{person.countCriminalRecord}}</p>
      <my-button>Подробнее</my-button>
      <my-button style="margin-left: 10px">Удалить</my-button>
    </div>
  </div>
</template>

<script>
import MyButton from "@/components/UI/MyButton";
export default {
  components: {MyButton},
  props : {
    person: {
      type: Object,
      required: true
    }
  }
}
</script>

<style scoped>

</style>