<template>
  <div class="m-3 p-3 bg-secondary lighten-20">
    <h4><span class="f-28">"</span><em>{{ review.body }}</em><span class="f-28">"</span></h4>
    <a class="text-end action" @click="goToProfile"> - {{ review.creator.name }}</a>
  </div>
</template>

<script>
import { Modal } from 'bootstrap'
import { useRouter } from 'vue-router'

export default {
  props: {
    review: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const router = useRouter()

    return {
      goToProfile() {
        Modal.getOrCreateInstance(document.getElementById('restaurant-modal')).hide()
        router.push({ name: "Profile", params: { id: props.review.creator.id } })
      }

    }
  }
}
</script>
<style lang="scss" scoped>
a {
  all: unset;
}

.action {
  cursor: pointer;

  &:hover {
    transform: scale(1.2)
  }
}
</style>


