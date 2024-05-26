import { configureStore } from "@reduxjs/toolkit"
import pageReducer from "./pageSlice"
import profileReducer from "./profileSlice"
import techsReducer from "./techsSlice"
export default configureStore({
	reducer: {
		page: pageReducer,
		profile: profileReducer,
		techs: techsReducer,
	},
})
