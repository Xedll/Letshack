import React, { useEffect, useState } from "react"
import { Header } from "../../Components/Header"
import { Footer } from "../../Components/Footer"
import { Tag } from "../../Components/Tag"

import ProfilePhoto from "../../Assets/photo.png"
import { useDispatch, useSelector } from "react-redux"
import { setContacts, setDescription, setName, setSearching, setSkills, setTeams } from "../../redux/profileSlice"
import axios from "axios"
import { TeamModal } from "../../Components/TeamModal"
import { ProfileTeamCard } from "../../Components/ProfileTeamCard"
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
	const [message, setMessage] = useState(null)
	const profile = useSelector((state) => state.profile)
	const techs = useSelector((state) => state.techs)
	const dispatch = useDispatch()
	const [isEditing, setIsEditing] = useState(false)
	const [isOpen, setIsOpen] = useState(false)
	const [techsBD, setTechsBD] = useState([])
	const [roles, setRoles] = useState([])
	useEffect(() => {
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
				setTechsBD(response.data)
			})
		axios
			.request({
				method: "GET",
				url: `${SITE_URL}/api/TeamRole`,
				headers: {
					"ngrok-skip-browser-warning": true,
				},
			})
			.then((response) => {
				console.log(response.data)
				setRoles(response.data)
			})
		axios
			.request({
				method: "GET",
				url: `${SITE_URL}/api/Profile/manage`,
				headers: {
					"ngrok-skip-browser-warning": true,
					Authorization: `bearer ${localStorage.getItem("token")}`,
				},
			})
			.then((response) => {
				const data = response.data
				dispatch(setName(data.initials))
				dispatch(setDescription(data.description))
				dispatch(setSkills(data.technologies))
				dispatch(setSearching(data.isVisible))
				dispatch(setContacts(data.tgId))
				dispatch(setTeams(data.createdTeams))
			})
	}, [])
	return (
		<div className='flex flex-col h-full w-full'>
			<Header />
			<TeamModal
				isOpen={isOpen}
				handlefunc={() => {
					setIsOpen(false)
					document.querySelector("body").classList.remove("modal-open")
				}}
				techs={roles}
			/>
			<div className=' h-full flex-[1_1_100%] flex max-w-7xl mt-6 w-full mx-auto py-12 gap-x-8'>
				<div className='max-w-[75%] w-full  flex flex-col gap-y-10 items-start '>
					<div className='w-full flex flex-col gap-y-4'>
						<img src={ProfilePhoto} alt='Profile Photo' className='max-w-36 max-h-36' />
						{(isEditing && (
							<input
								type='text'
								className='w-full h-full rounded-md border-solid p-2 border-rounded border-2 border-[#1D1F244D]'
								onChange={(e) => {
									dispatch(setName(e.target.value))
								}}
								value={profile.name || ""}
							></input>
						)) || <p>{profile.name}</p>}
					</div>
					<div className='w-full flex gap-x-6'>
						<button
							className='py-2 bg-ourPink px-6 text-[#fff] rounded-3xl font-medium text-base '
							onClick={() => {
								if (!profile.description && !profile.name) {
									setMessage("Описание и имя обязательные поля")
								} else if (!profile.description) {
									setMessage("Описание - обязательное поле")
								} else if (!profile.name) {
									setMessage("Имя - обязательное поле")
								} else {
									setIsOpen(true)
									document.querySelector("body").classList.add("modal-open")
								}
							}}
						>
							Создать команду
						</button>
						<div className='flex items-center gap-x-2'>
							<button
								className={`${
									profile.searching ? "bg-ourPink text-[#FFF]" : "bg-[#fff] border-2 border-ourPink text-ourPink"
								} py-2 px-6 rounded-3xl font-medium text-base`}
								onClick={async () => {
									dispatch(setSearching(!profile.searching))
									axios
										.request({
											method: "put",
											url: `${SITE_URL}/api/Profile/manage/visible`,
											headers: {
												Authorization: `bearer ${localStorage.getItem("token")}`,
												"Content-Type": "application/json",
											},

											data: JSON.stringify({
												isVisible: !profile.searching,
											}),
										})
										.then((respons) => {
											console.log(respons)
										})
										.catch((err) => {
											console.log(err)
										})
								}}
							>
								{profile.searching ? "Я и" : "Я не и"}щу команду
							</button>
						</div>
					</div>
					<div className='w-full flex flex-col gap-y-4'>
						<p className='font-medium text-[#1D1F2466] text-base'>Расскажите о себе</p>
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
						<p className='font-medium text-[#1D1F2466] text-base'>Контактные данные</p>
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
						<p className='font-medium text-[#1D1F2466] text-base'>Ваши навыки</p>
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
						className='py-2 bg-ourPink px-6 text-[#fff] rounded-3xl font-medium text-base '
						onClick={() => {
							if (!isEditing) setIsEditing(!isEditing)
							if (isEditing) {
								let idSkills = []
								for (let item of profile.skills) {
									idSkills.push(item.id)
								}
								axios
									.request({
										method: "POST",
										url: `${SITE_URL}/api/Profile/manage`,
										headers: {
											Authorization: `bearer ${localStorage.getItem("token")}`,
											"Content-Type": "application/json",
										},
										data: JSON.stringify({
											initials: profile.name,
											Description: profile.description,
											email: "string",
											number: "string",
											tgId: profile.contacts || "",
											isVisible: profile.searching || false,
											technologiesList: idSkills || [],
										}),
									})
									.then((response) => {
										setIsEditing(!isEditing)
										setMessage(null)
									})
									.catch((err) => {
										if (err.response.data.errors) {
											let errData = err.response.data.errors
											if (errData.Description && errData.initials) {
												setMessage("Описание и имя обязательные поля")
											} else if (errData.Description) {
												setMessage("Описание - обязательное поле")
											} else {
												setMessage("Имя - обязательное поле")
											}
										}
									})
							}
						}}
					>
						{isEditing ? "Сохранить изменения" : "Изменить профиль"}
					</button>
					{message && <p className='font-medium text-ourGrey text-4xl mb-4'>{message}</p>}
				</div>
				<div className='max-w-[25%] w-full h-full border-solid border-2 rounded-xl border-[#1D1F244D] bg-[#F6F6F6] p-4'>
					<p className='mb-4 text-xl font-medium text-ourPink'>История создания команд</p>
					<div className='flex flex-col h-full '>
						{profile.teams &&
							profile.teams.map((item, index) => {
								return <ProfileTeamCard key={index} title={item.title} description={item.description} />
							})}
					</div>
				</div>
			</div>
			<Footer />
		</div>
	)
}
