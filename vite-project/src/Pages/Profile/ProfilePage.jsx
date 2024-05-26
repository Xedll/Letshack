import React, { useState } from "react"
import { Header } from "../../Components/Header"
import { Footer } from "../../Components/Footer"
import { Tag } from "../../Components/Tag"

import ProfilePhoto from "../../Assets/photo.png"
import { useDispatch, useSelector } from "react-redux"
import { setContacts, setDescription, setSkills } from "../../redux/profileSlice"
import axios from "axios"
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
export const ProfilePage = () => {
	const profile = useSelector((state) => state.profile)
	const techs = useSelector((state) => state.techs)
	const dispatch = useDispatch()
	const [isEditing, setIsEditing] = useState(false)
	return (
		<>
			<Header />
			<div className=' h-full flex-[1_1_100%] flex max-w-7xl mt-6 w-full mx-auto'>
				<div className='max-w-[75%] w-full  flex flex-col gap-y-10 items-start '>
					<div className='w-full flex flex-col gap-y-4'>
						<img src={ProfilePhoto} alt='Profile Photo' className='max-w-36 max-h-36' />
						<p>Андрей Андреевич Андреев</p>
					</div>
					<div className='w-full flex gap-x-6'>
						<button className='py-2 bg-ourPink px-6 text-[#fff] rounded-3xl font-medium font-base '>Создать команду</button>
						<div className='flex items-center gap-x-2'>
							<p>Ищу команду</p>
							<input type='checkbox' className='py-2 bg-ourPink px-6 text-[#fff] rounded-3xl font-medium font-base ' />
						</div>
					</div>
					<div className='w-full flex flex-col gap-y-4'>
						<p className='font-medium text-[#1D1F2466] font-base'>Расскажите о себе</p>
						{(isEditing && (
							<textarea
								className='w-full h-full resize-none rounded-md border-solid p-2 border-rounded border-2 border-[#1D1F244D]'
								name=''
								id=''
								onChange={(e) => {
									dispatch(setDescription(e.target.value))
								}}
								value={profile.description || ""}
							></textarea>
						)) || <p>{profile.description}</p>}
					</div>
					<div className='w-full flex flex-col gap-y-4'>
						<p className='font-medium text-[#1D1F2466] font-base'>Контактные данные</p>
						{(isEditing && (
							<textarea
								className='w-full h-full resize-none rounded-md border-solid p-2 border-rounded border-2 border-[#1D1F244D]'
								name=''
								id=''
								onChange={(e) => {
									dispatch(setContacts(e.target.value))
								}}
								value={profile.contacts || ""}
							></textarea>
						)) || <p>{profile.contacts}</p>}
					</div>
					<div className='w-full flex flex-col gap-y-4'>
						<p className='font-medium text-[#1D1F2466] font-base'>Ваши навыки</p>
						<div className='flex gap-x-4'>
							{!isEditing &&
								profile.skills &&
								profile.skills.map((item, index) => {
									return <Tag key={index} text={`${item.title}`} color={"ourPink"} />
								})}
							{isEditing && (
								<div className='flex flex-col gap-y-6'>
									<div className='flex gap-x-4'>
										{profile.skills &&
											profile.skills.map((item, index) => {
												if (!(isEditing && isInArray(item.title, profile.skills || []))) return
												return (
													<Tag
														key={index}
														text={`${item.title}  ${String.fromCharCode(10006)}`}
														color={"ourPink"}
														handlefunc={() => {
															if (profile.skills.length == 1) return dispatch(setSkills([]))
															else {
																let test = Array.from(profile.skills)
																test.splice(indexInArray(item.title, profile.skills), 1)
																Array.from(profile.skills).splice(indexInArray(item.title, profile.skills), 1)
																return dispatch(setSkills(test))
															}
														}}
													/>
												)
											})}
									</div>
									<div className='flex gap-x-4'>
										{techs.technologies.map((item, index) => {
											if (isEditing && isInArray(item.title, profile.skills || [])) return
											return (
												<Tag
													key={index}
													text={`${item.title}`}
													color={"ourGrey"}
													handlefunc={() => {
														if (profile.skills) return dispatch(setSkills([].concat(profile.skills, item)))
														else dispatch(setSkills([item]))
													}}
												/>
											)
										})}
									</div>
								</div>
							)}
						</div>
					</div>
					<button
						className='py-2 bg-ourPink px-6 text-[#fff] rounded-3xl font-medium font-base '
						onClick={() => {
							setIsEditing(!isEditing)
							if (isEditing) {
								axios
									.request({
										method: "POST",
										url: `${SITE_URL}/api/Profile/manage`,
										headers: {
											Authorization: `bearer ${localStorage.getItem("token")}`,
											"Content-Type": "application/json",
										},
										body: JSON.stringify({
											initials: profile.name,
											description: profile.description,
											email: "string",
											number: "string",
											tgId: profile.contacts,
											isVisible: profile.searching,
											technologiesList: profile.skills,
										}),
									})
									.then((response) => {
										console.log(response)
									})
									.catch((err) => {
										console.log(err)
									})
							}
						}}
					>
						{isEditing ? "Сохранить изменения" : "Изменить профиль"}
					</button>
				</div>
				<div className='max-w-[25%] w-full'>
					<div className='grid'></div>
				</div>
			</div>
			<Footer />
		</>
	)
}
