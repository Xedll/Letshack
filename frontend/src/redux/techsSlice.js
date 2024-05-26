import { createSlice } from "@reduxjs/toolkit"

export const techsSlice = createSlice({
	name: "techs",
	initialState: {
		technologies: [
			{
				id: 1,
				title: "HTML",
			},
			{
				id: 2,
				title: "Css",
			},
			{
				id: 3,
				title: "Docker",
			},
			{
				id: 4,
				title: "Kotlin",
			},
			{
				id: 5,
				title: "Java",
			},
			{
				id: 6,
				title: "Flutter",
			},
			{
				id: 7,
				title: "Go",
			},
			{
				id: 8,
				title: "PostgreSQL",
			},
			{
				id: 9,
				title: "MongoDB",
			},
			{
				id: 10,
				title: "gRPC",
			},
		],
		topics: [],
	},
	reducers: {
		setTechnologies: (state, action) => {
			state.technologies = action.payload
		},
		setTopics: (state, action) => {
			state.topics = action.payload
		},
	},
})
export const { setTechnologies, setTopics } = techsSlice.actions

export default techsSlice.reducer
