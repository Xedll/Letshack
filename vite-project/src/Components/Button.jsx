import React from "react"

export const Button = ({ title, handlefunc }) => {
	return (
		<button className='w-full py-6 bg-ourPink rounded-3xl text-[#fff] text-medium text-xl' onClick={handlefunc}>
			{title}
		</button>
	)
}
