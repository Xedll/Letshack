import React from "react"

export const Input = ({ title, placeholder, handlefunc }) => {
	return (
		<div>
			<p className='mb-4 text-pink text-xl'>{title}</p>
			<input
				type='text'
				placeholder={placeholder}
				onChange={handlefunc}
				className='w-full p-4 border-2 border-[#AAABAD] border-solid rounded-2xl focus:outline-none'
			/>
		</div>
	)
}
