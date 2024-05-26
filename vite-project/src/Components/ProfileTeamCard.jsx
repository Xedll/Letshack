import React from "react"

export const ProfileTeamCard = ({ title, description }) => {
	return (
		<div className='w-full h-fit border-2 rounded-xl border-solid border-[#1D1F244D] bg-[#fff] flex gap-x-4 items-center p-2 max-h-20'>
			<div className='bg-placeholder bg-center bg-cover h-full w-1/3' />
			<div className='flex flex-col justify-between  h-full text-sm'>
				<p className='text-ourPink'>Название: {title}</p>
				<p className='text-[#1D1F2499] h-fit overflow-auto'>Описание: {description}</p>
			</div>
		</div>
	)
}
