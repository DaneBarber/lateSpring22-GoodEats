<template>
  <Modal id="restaurant-modal">
    <template #modal-title>{{ restaurant.name }}</template>
    <template #modal-body>
      <div class="container">
        <div class="row">
          <div class="col-md-6">
            <img class="img-fluid" :src="restaurant.picture" :alt="restaurant.name + ' picture'">
          </div>
          <div class="col-md-6">
            <div class="ms-4 d-flex flex-column justify-content-center">
              <h3 class="pb-2 border-bottom border-secondary">{{ restaurant.name }} <small> <kbd class="">{{
                  restaurant.category
              }}</kbd></small></h3>
              <p>{{ restaurant.location }}</p>
            </div>
            <div class="mt-4">
              <form @submit.prevent="createReview" class="text-end">
                <div class="d-flex justify-content-between">
                  <label for="body"><small>Write a review</small></label>
                  <div class="d-flex flex-column">
                    <label for="rating"><small>rating</small></label>
                    <input type="number" min="1" max="5" required v-model="review.rating" />
                  </div>
                </div>
                <textarea class="w-100" name="body" id="body" rows="5" v-model="review.body"></textarea>
                <button class="btn btn-success">Submit</button>
              </form>
            </div>
            <div class="mt-4 reviews scrollable-y">
              <Review v-for="r in reviews" :key="r.id" :review="r" />
            </div>
          </div>
        </div>
      </div>
    </template>
  </Modal>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState.js'
import { reviewsService } from '../services/ReviewsService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'

export default {
  setup() {
    const review = reactive({})

    return {
      review,
      restaurant: computed(() => AppState.activeRestaurant),
      reviews: computed(() => AppState.reviews),
      async createReview() {
        try {
          await reviewsService.createReview({ body: review.body, rating: review.rating, restaurantId: AppState.activeRestaurant.id })
        } catch (error) {
          Pop.toast("Call the MIB", 'error')
          logger.log(error)
        }
      }
    }
  }
}
</script>
<style scoped>
img {
  width: 100%;
  object-fit: cover;
}

.reviews {
  max-height: 30vh;
}
</style>