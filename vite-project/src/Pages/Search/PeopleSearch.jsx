import React, { useState } from "react"
import { PeopleCard } from "../../Components/PeopleCard"
import { Header } from "../../Components/Header"

import { Footer } from "../../Components/Footer"

export const PeopleSearch = () => {
	const [searchTitle, setSearchTitle] = useState(null)
	const data = ["Андрей", "Андрей2", "tjaowtjoe", "tjaowtjoe", "tjaowtjoe", "tjaowtjoe", "tjaowtjoe"]
	return (
		<div className='flex flex-col h-full w-full'>
			<Header />
			<div className='flex-[1_1_100%] flex flex-col  mt-16'>
				<div className='gap-y-8 flex flex-col max-w-7xl w-full mx-auto '>
					<p className='font-semibold text-2xl'>Найди участника в свою команду</p>
					<div className='flex gap-x-8 items-center'>
						<input
							type='text'
							className='bg-[#FAFAFA] border-solid border-rounded rounded-xl border-2 border-[#1D1F2440] w-1/3 p-2 focus:outline-none'
							onChange={(e) => {
								setSearchTitle(e.target.value)
							}}
						/>
						<div className='bg-filter2 w-8 h-8 cursor-pointer bg-center bg-no-repeat' />
					</div>
					<div className='grid gap-8 grid-cols-4 mb-8  transition-all duration-300'>
						{data.map((element, index) => {
							if (!searchTitle || element.toLowerCase().indexOf(searchTitle.toLowerCase()) != -1) {
								return <PeopleCard key={index} Title={element} />
							}
						})}
					</div>
				</div>
			</div>
			<Footer />
		</div>
	)
}
