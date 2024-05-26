import React from "react"

export const Tag = ({ text, color, handlefunc }) => {
	return (
		<div
			className={`cursor-pointer select-none bg-[#FFF] px-2 py-1  border-rounded rounded-xl border-2 border-${color} border-solid text-${color} w-fit h-fit font-semibold text-xs`}
			onClick={handlefunc}
		>
			{text}
		</div>
	)
}
