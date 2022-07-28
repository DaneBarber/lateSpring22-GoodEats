<template>
  <div class="container">
    <div class="row">
      <div class="col d-flex mt-4">
        <img :src="profile.picture" class="rounded-pill">
        <div>
          <h3>{{ profile.name }}</h3>
          <h4>Total Reviews: {{ reviews.length }}</h4>
          <h4>Average Review: {{ averageReview }}</h4>
        </div>
      </div>
    </div>
    <!-- REVIEW MASONRY CANNOT BE IN A ROW OR ANY D_FLEX CONTAINER!!!!!!!! -->
    <div class="masonry-frame">
      <div v-for="rv in reviews" :key="rv.id">
        <Review :review="rv" />
      </div>
    </div>
  </div>
</template>


<script>
import { computed, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState.js'
import { profilesService } from '../services/ProfilesService.js'
import { reviewsService } from '../services/ReviewsService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'

export default {
  setup() {
    const route = useRoute()
    onMounted(async () => {
      try {
        await profilesService.getProfile(route.params.id)
        await reviewsService.getReviewsByProfileId(route.params.id)
      } catch (error) {
        logger.log(error)
        Pop.toast("OH NOOOS", 'error')
      }
    })
    return {
      profile: computed(() => AppState.activeProfile),
      reviews: computed(() => AppState.profileReviews),
      averageReview: computed(() => {
        let total = 0
        AppState.profileReviews.forEach(r => total += r.rating)
        return (total / AppState.profileReviews.length).toFixed(2)
      })
    }
  }
}
</script>


<style lang="scss" scoped>
.masonry-frame {
  columns: 4;

  div {
    break-inside: avoid;
  }
}
</style>