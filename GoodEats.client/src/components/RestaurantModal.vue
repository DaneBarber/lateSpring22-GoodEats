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
              <form class="text-end">
                <div class="d-flex justify-content-between">
                  <label for="body"><small>Write a review</small></label>
                  <div class="d-flex flex-column">
                    <label for="rating"><small>rating</small></label>
                    <input type="number" min="1" max="5" />
                  </div>
                </div>
                <textarea class="w-100" name="body" id="body" rows="5"></textarea>
                <button class="btn btn-success">Submit</button>
              </form>
            </div>
            <div> {{ reviews }} </div>
          </div>
        </div>
      </div>
    </template>
  </Modal>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState.js'

export default {
  setup() {
    return {
      restaurant: computed(() => AppState.activeRestaurant),
      reviews: computed(() => AppState.reviews)
    }
  }
}
</script>
<style scoped>
img {
  width: 100%;
  object-fit: cover;
}
</style>