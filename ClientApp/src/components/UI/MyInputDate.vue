<template>
  <input :value="modelValue" @input="updateInput" class="input" type="date">
</template>

<script>
export default {
  name: 'my-input-date',
  props: {
    modelValue: [String]
  },
  methods: {
    updateInput(event) {
      this.$emit('update:modelValue', event.target.value)
    }
  }
}
</script>

<style scoped>
.input {
  width: 100%;
  border: 1px solid chocolate;
  padding: 10px 15px;
  margin-top: 15px;
}

</style>