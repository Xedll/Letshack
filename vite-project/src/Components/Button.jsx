import React from "react"

export const Button = ({ title, handlefunc }) => {
	return (
		<button className='w-full py-6 bg-pink rounded-3xl text-[#fff] text-medium text-xl' onClick={handlefunc}>
			{title}
		</button>
	)
}
