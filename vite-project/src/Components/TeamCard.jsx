import React, { useState } from "react"
import TeamPlaceholder from "../Assets/CardPlaceholder.jpg"
import { Tag } from "./Tag"

export const TeamCard = ({ Title, date, description, marks, contacts }) => {
	const [isMouseOn, setIsMouseOn] = useState(false)

	return (
		<div
			className='border-solid border-rounded rounded-xl border-[#C5C6C7] h-fit border-2 p-4 w-full'
			onMouseEnter={() => setIsMouseOn(!isMouseOn)}
			onMouseLeave={() => setIsMouseOn(!isMouseOn)}
		>
			<div className='mb-4 w-full flex justify-center'>
				<img src={TeamPlaceholder} alt='Team Photo' className='max-w-full max-h-full' />
			</div>
			<div className={`flex flex-col gap-y-3 mb-4  ${isMouseOn ? "hidden" : "flex"}`}>
				<div className='flex gap-x-2'>
					{marks &&
						marks.array.forEach((element) => {
							return <Tag text={element} color={"ourPink"} />
						})}
					<Tag text={"HTML"} color={"ourPink"} />
				</div>
				<div className='font-semibold text-ourPink font-base'>{Title || "Требуется: дизайнер"}</div>
				<div className='font-xs text-[#1D1F2480]'>{date || "г. Казань, 22-23 апреля"}</div>
			</div>
			<div className={` flex-col gap-y-3 mb-4  ${isMouseOn ? "flex" : "hidden"}`}>
				<p className='text-ourPink font-base font-semibold'>Описание</p>
				<p className='text-[#1D1F2480] font-xs '>
					{description || "Мы ищем дизайнера, с опытом участия в хакатонах. Требуется создать 2 странички и лэндинг с регистрацией"}
				</p>
			</div>
			<button className='font-sm text-[#FFF] bg-ourPink border-rounded rounded-3xl w-full h-fit py-4 '>{contacts || "Откликнуться"}</button>
		</div>
	)
}
