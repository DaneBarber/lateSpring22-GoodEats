<template>
  <div data-bs-target="#restaurant-modal" data-bs-toggle="modal"
    class="m-4 elevation-2 d-flex justify-content-between selectable" @click="setActive">
    <div class="d-flex">
      <img class="img-fluid" :src="restaurant.picture" :alt="restaurant.name + ' picture'">
      <div class="ms-4 d-flex flex-column justify-content-center">
        <h3 class="pb-2 border-bottom border-secondary">{{ restaurant.name }} <small> <kbd class="">{{
            restaurant.category
        }}</kbd></small></h3>
        <p>{{ restaurant.location }}</p>
      </div>
    </div>
    <div class="m-3 justify-self-end">
      <h5 class="text-uppercase">Rating: {{ restaurant.averageRating }}<i class="mdi mdi-star text-warning"></i> ({{
          restaurant.totalReviews
      }})</h5>
    </div>
  </div>
</template>



<script>
import { restaurantsService } from '../services/RestaurantsService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'

export default {
  props: {
    restaurant: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      async setActive() {
        try {
          restaurantsService.setActive(props.restaurant)
        } catch (error) {
          Pop.toast("Something went wrong", "error")
          logger.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 200px;
  width: 250px;
  object-fit: cover;
}
</style>