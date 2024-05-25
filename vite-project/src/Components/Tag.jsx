import React from "react"

export const Tag = ({ text }) => {
	return (
		<div className='cursor-pinter select-none bg-[#FFF] px-2 py-1  border-rounded rounded-xl border-2 border-pink border-solid text-pink w-fit h-fit font-semibold text-xs'>
			{text}
		</div>
	)
}
