/** @type {import('tailwindcss').Config} */
export default {
	content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
	theme: {
		extend: {
			backgroundImage: {
				registerBG: "url('./src/Assets/registerBG.jpg')",
			},
		},
		colors: {
			pink: "#F21874",
		},
		fontFamily: {
			TTTravels: ['"TT Travels"', "sans-serif"],
		},
	},
	plugins: [],
}
