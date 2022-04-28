<template>
  <button class="btn btn-warning" type="button">
    <slot></slot>
  </button>
</template>

<script>

export default {


  name: 'my-button'
}
</script>

<style scoped>
.btn {
  margin: 10px 0px;
  padding: 10px 15px;
  background: none;
  color : chocolate;
  border: 1px solid chocolate;
}
</style>