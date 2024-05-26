import React, { useEffect, useState } from "react"
import { PeopleCard } from "../../Components/PeopleCard"
import { Header } from "../../Components/Header"

import { Footer } from "../../Components/Footer"
import axios from "axios"
import { Filter } from "../../Components/Filter"
const SITE_URL = import.meta.env.VITE_SITE_URL || ""

const isInArray = (item, array2) => {
	let flag = false
	for (let element of array2) {
		if (item == element.title) {
			flag = true
			break
		}
	}
	return flag
}
const indexInArray = (item, array2) => {
	let i = 0
	for (let element of array2) {
		if (item == element.title) {
			return i
		}
		i++
	}
	return -1
}
export const PeopleSearch = () => {
	const [searchTitle, setSearchTitle] = useState(null)
	const [users, setUsers] = useState([])
	const [techs, setTechs] = useState([])
	const [filters, setFilters] = useState([])

	const [numero, setNumero] = useState(0)
	useEffect(() => {}, [numero])

	const handleFilter = (item) => {
		if (isInArray(item.title, filters)) {
			if (filters.length == 1) {
				setFilters([])
			} else {
				let test = filters
				test.splice(indexInArray(item.title, filters), 1)
				setFilters(test)
			}
		} else {
			setFilters([...filters, item])
		}
		setNumero(Math.random())
	}
	useEffect(() => {
		axios
			.request({
				method: "GET",
				url: `${SITE_URL}/api/User`,
				headers: {
					"ngrok-skip-browser-warning": true,
				},
			})
			.then((response) => {
				setUsers(response.data)
			})
		axios
			.request({
				method: "GET",
				url: `${SITE_URL}/api/Technology`,
				headers: {
					"ngrok-skip-browser-warning": true,
				},
			})
			.then((response) => {
				console.log(response.data)
				setTechs(response.data)
			})
	}, [])
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
						<Filter color={"orange"} data={techs} handlefunc={handleFilter} />
					</div>
					<div className='grid gap-8 grid-cols-4 mb-8  transition-all duration-300'>
						{users.map((element, index) => {
							let flag = false
							for (let filter of filters) {
								if (isInArray(filter.title, element.technologies)) {
									flag = true
								}
							}
							if (filters.length == 0) {
								flag = true
							}
							if ((!searchTitle || element.initials.toLowerCase().indexOf(searchTitle.toLowerCase()) != -1) && element.isVisible && flag) {
								return (
									<PeopleCard
										key={index}
										Title={element.initials}
										description={element.description}
										marks={element.technologies}
										contacts={element.tgId}
									/>
								)
							}
						})}
					</div>
				</div>
			</div>
			<Footer />
		</div>
	)
}
