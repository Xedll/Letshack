import React, { useEffect, useState } from "react"
import { Tag } from "./Tag"
import CrossPNG from "../Assets/cross.png"
const SITE_URL = import.meta.env.VITE_SITE_URL || ""
import axios from "axios"
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
export const TeamModal = ({ techs, isOpen, handlefunc }) => {
	const [message, setMessage] = useState(null)
	const [selectedTechs, setSelectedTechs] = useState([])
	const [title, setTitle] = useState("")
	const [description, setDescription] = useState("")
	const [numero, setNumero] = useState(0)
	useEffect(() => {}, [numero])
	return (
		<div
			className={`${
				isOpen ? "absolute" : "hidden"
			} right-1/2 bottom-1/2 translate-x-1/2 translate-y-1/2 w-1/2 h-96 p-8 border-2 border-solid rounded-xl border-ourOrange flex flex-col gap-y-4 bg-[#fff]`}
		>
			<div className='flex items-center justify-between'>
				<div>
					{message && <p className='font-medium text-ourGrey text-xl mb-4'>{message}</p>}
					<p className='font-medium text-xl text-ourPink'>Создать команду</p>
				</div>
				<p
					className='cursor-pointer'
					onClick={() => {
						handlefunc()
						setDescription("")
						setTitle("")
						setSelectedTechs([])
						setMessage(null)
						setNumero(Math.random())
					}}
				>
					<img src={CrossPNG} alt='exit' />
				</p>
			</div>
			<div className='h-full flex gap-x-8 '>
				<div className='w-1/2 h-full flex flex-col gap-y-4'>
					<div className='flex flex-col gap-y-4'>
						<p className='font-medium text-base'>Название команды</p>
						<input
							type='text'
							className='w-full resize-none rounded-md border-solid p-2 border-rounded border-2 border-[#1D1F244D] focus:outline-none'
							onChange={(e) => {
								setTitle(e.target.value)
							}}
						/>
					</div>
					<div className='h-full flex flex-col gap-y-4'>
						<p>Описание</p>
						<textarea
							id=''
							className='w-full h-full  resize-none rounded-md border-solid p-2 border-rounded border-2 border-[#1D1F244D] focus:outline-none'
							onChange={(e) => {
								setDescription(e.target.value)
							}}
						></textarea>
					</div>
				</div>
				<div className='w-1/2 h-full  flex flex-col gap-y-4'>
					<div className='h-full flex flex-col gap-y-4'>
						<p>Нужный стек</p>
						<div className='flex flex-wrap gap-4 '>
							{techs &&
								techs.map((item, index) => {
									let flag = false
									if (isInArray(item.title, selectedTechs)) {
										flag = true
									}
									return (
										<Tag
											color={"ourPink"}
											text={`${item.title} ${flag ? String.fromCharCode(10003) : ""}`}
											key={index}
											handlefunc={() => {
												if (isInArray(item.title, selectedTechs)) {
													if (selectedTechs.length == 1) {
														setSelectedTechs([])
													} else {
														let test = selectedTechs
														test.splice(indexInArray(item.title, selectedTechs), 1)
														setSelectedTechs(test)
													}
												} else {
													setSelectedTechs([...selectedTechs, item])
												}
												setNumero(Math.random())
											}}
										/>
									)
								})}
						</div>
					</div>
					<button
						className='px-4 py-2 font-medium text-xl text-[#fff] bg-ourPink rounded-xl'
						onClick={() => {
							let neededRoles = []
							for (let item of selectedTechs) {
								neededRoles.push(item.id)
							}
							console.log(
								JSON.stringify({
									title: title,
									description: description,
									neededRoles: neededRoles,
								})
							)
							axios
								.request({
									method: "POST",
									url: `${SITE_URL}/api/Team`,
									headers: {
										"Content-Type": "application/json",
										Authorization: `bearer ${localStorage.getItem("token")}`,
									},
									data: JSON.stringify({
										title: title,
										description: description,
										neededRoles: neededRoles,
									}),
								})
								.then((response) => {
									console.log(response)
									handlefunc()
									setDescription("")
									setTitle("")
									setSelectedTechs([])
									setMessage(null)
									setNumero(Math.random())
								})
								.catch((err) => {
									setMessage("Что-то пошло не так. Попробуйте позже.")
									console.log(err)
									setTimeout(() => {
										setMessage(null)
									}, 3000)
								})
						}}
					>
						Создать команду
					</button>
				</div>
			</div>
		</div>
	)
}
