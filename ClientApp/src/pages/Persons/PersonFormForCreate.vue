<template>
  <form @submit.prevent>
    <h4>Создать</h4>

    <my-input
        v-model="newPerson.name"
        type="text"
        placeholder="Имя"
    />
    <my-input
        v-model="newPerson.surName"
        type="text"
        placeholder="Фамилия"
    />
    <my-input
        v-model="newPerson.address"
        type="text"
        placeholder="Адрес проживания"
    />
    <my-input
        v-model="newPerson.countCriminalRecord"
        type="text"
        placeholder="Кол-во судимостей"
    />
    <my-button
        style="align-self: flex-end; margin-top: 15px"
        @click="createPerson"
    >
      Создать
    </my-button>
  </form>
</template>

<script>

export default {

  data() {
    return {
      newPerson: {
        name: '',
        surName: '',
        address: '',
        countCriminalRecord: 0
      }
    }
  },
  methods: {
    createPerson() {

      this.$emit('create', this.newPerson)
      this.newPerson = {
        name: '',
        surName: '',
        address: '',
        countCriminalRecord: 0
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