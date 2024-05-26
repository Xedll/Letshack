import { createSlice } from "@reduxjs/toolkit"

export const profileSlice = createSlice({
	name: "profile",
	initialState: {
		name: null,
		description: null,
		contacts: null,
		skills: null,
		searching: false,
		teams: null,
	},
	reducers: {
		setName: (state, action) => {
			state.name = action.payload
		},
		setDescription: (state, action) => {
			state.description = action.payload
		},
		setContacts: (state, action) => {
			state.contacts = action.payload
		},
		setSkills: (state, action) => {
			state.skills = action.payload
		},
		setSearching: (state, action) => {
			state.searching = action.payload
		},
		setTeams: (state, action) => {
			state.teams = action.payload
		},
	},
})
export const { setName, setDescription, setContacts, setSkills, setSearching, setTeams } = profileSlice.actions

export default profileSlice.reducer
