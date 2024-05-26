import React, { useState } from "react"
import TeamPlaceholder from "../Assets/CardPlaceholder.jpg"
import { Tag } from "./Tag"

export const PeopleCard = ({ Title, description, marks, contacts }) => {
	const [isMouseOn, setIsMouseOn] = useState(false)

	return (
		<div
			className='border-solid border-rounded rounded-xl border-[#C5C6C7] h-fit border-2 p-4 w-full'
			onMouseEnter={() => setIsMouseOn(true)}
			onMouseLeave={() => setIsMouseOn(false)}
		>
			<div className='mb-4 w-full h-32 flex justify-center bg-placeholder bg-center bg-cover' />
			<div className={`flex flex-col gap-y-3 mb-4  ${isMouseOn ? "hidden" : "flex"}`}>
				<div className='flex gap-2 flex-wrap'>
					{marks &&
						marks.map((element, index) => {
							return <Tag key={index} text={element.title} color={"ourOrange"} />
						})}
				</div>
				<div className='font-semibold text-ourOrange text-base'>{Title}</div>
			</div>
			<div className={` flex-col gap-y-3 mb-4  ${isMouseOn ? "flex" : "hidden"}`}>
				<p className='text-ourOrange text-base font-semibold'>Описание</p>
				<p className='text-[#1D1F2480] font-xs '>{description}</p>
			</div>
			<button className='font-sm text-[#FFF] bg-ourOrange border-rounded rounded-3xl w-full h-fit py-4 '>{contacts}</button>
		</div>
	)
}
