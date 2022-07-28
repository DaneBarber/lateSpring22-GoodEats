import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ReviewsService {
  async getReviewsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/reviews`)
    AppState.profileReviews = [...res.data, ...res.data.reverse(), ...res.data, ...res.data.reverse()]
  }

  async createReview(newReview) {
    const res = await api.post('api/reviews', newReview)
    logger.log(res.data)
    AppState.reviews.push(res.data)


  }
}

export const reviewsService = new ReviewsService()