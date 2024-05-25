import React, { useState } from "react"
import TeamPlaceholder from "../Assets/CardPlaceholder.jpg"
import { Tag } from "./Tag"

export const TeamCard = () => {
	const [isHovered, setIsHovered] = useState(false)

	const handleHover = () => setIsHovered(!isHovered)
	return (
		<div
			className='absolute top-1/2 left-1/2 border-solid border-rounded rounded-xl border-[#C5C6C7] w-full h-fit border-2 p-4 max-w-72'
			onMouseEnter={handleHover}
			onMouseLeave={handleHover}
		>
			<div className='mb-4'>
				<img src={TeamPlaceholder} alt='' className='max-w-full max-h-full' />
			</div>
			<div className={` flex-col gap-y-3 mb-4 ${isHovered ? "hidden" : "flex"}`}>
				<div className='flex gap-x-2'>
					<Tag text={"CSS"} />
					<Tag text={"HTML"} />
				</div>
				<div className='font-semibold text-pink font-base'>Требуется: дизайнер</div>
				<div className='font-xs text-[#1D1F2480]'>г. Казань, 22-23 апреля</div>
			</div>
			<div className={` flex-col gap-y-3 mb-4 ${isHovered ? "flex" : "hidden"}`}>
				<p className='text-pink font-base font-semibold'>Описание</p>
				<p className='text-[#1D1F2480] font-xs'>
					Мы ищем дизайнера, с опытом участия в хакатонах. Требуется создать 2 странички и лэндинг с регистрацией
				</p>
			</div>
			<button className='font-sm text-[#FFF] bg-pink border-rounded rounded-3xl w-full h-fit py-4 '>Откликнуться</button>
		</div>
	)
}
