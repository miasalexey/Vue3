<template>
  <form @submit.prevent>
    <h4>Создать происшествие</h4>
    <my-input-date
      v-model="newCriminalCase.dataRegistration"
      type="date"
      placeholder="Date"
    />
    <my-input
        v-model="newCriminalCase.title"
        type="text"
        placeholder="Описание"
    />
    <my-input
        v-model="newCriminalCase.region"
        type="text"
        placeholder="Регион"
    />
    <my-button
        style="align-self: flex-end; margin-top: 15px"
        @click="createCriminalCase"
    >
      Создать
    </my-button>
  </form>
</template>

<script>
import MyInputDate from "@/components/UI/MyInputDate";

export default {
  components: [MyInputDate],
  data() {
    return {
      newCriminalCase: {
        dataRegistration: '',
        title: '',
        region: '',
      }
    }
  },
  methods: {
    createCriminalCase() {

      this.$emit('create', this.newCriminalCase)
      this.newCriminalCase = {
        dataRegistration: '',
        title: '',
        region: ''
      }
    }
  },
}
</script>

<style scoped>
form {
  display: flex;
  flex-direction: column;
}

</style>