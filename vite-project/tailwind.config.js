/** @type {import('tailwindcss').Config} */
export default {
	content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
	theme: {
		extend: {
			backgroundImage: {
				registerBG: "url('./src/Assets/registerBG.jpg')",
				filter: "url('./src/Assets/filter.png')",
				filter2: "url('./src/Assets/filter2.png')",
				placeholder: "url('./src/Assets/placeholder.jpg')",
			},
			colors: {
				ourPink: "#F21874",
				ourOrange: "#F28118",
				ourGrey: "#BBBBBD",
			},
		},

		fontFamily: {
			TTTravels: ['"TT Travels"', "sans-serif"],
		},
	},
	plugins: [],
}
