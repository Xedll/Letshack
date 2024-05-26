import { createSlice } from "@reduxjs/toolkit"

export const pageSlice = createSlice({
	name: "page",
	initialState: {
		page: null,
	},
	reducers: {
		setPage: (state, action) => {
			state.page = action.payload
		},
	},
})
export const { setPage } = pageSlice.actions

export default pageSlice.reducer
