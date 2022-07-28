<template>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <Restaurant v-for="r in restaurants" :key="r.id" :restaurant="r" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState.js'
import { restaurantsService } from '../services/RestaurantsService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'

export default {
  name: 'Home',
  setup() {
    onMounted(async () => {
      try {
        await restaurantsService.getAll()
      } catch (error) {
        Pop.toast('Failed to load Restaurants', 'error')
        logger.error(error)
      }
    })
    return {
      restaurants: computed(() => AppState.restaurants)
    }
  }
}
</script>

<style scoped lang="scss">
</style>
